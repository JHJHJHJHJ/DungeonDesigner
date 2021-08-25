using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using DD.Object;
using DD.Core;
using DD.PlayData;
using DD.FX;
using DD.Inventory;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] float maxHealthPoints = 100f;

        [Header("Reference")]
        [SerializeField] DamageText damageTextPrefab = null;
        [SerializeField] Transform floatingPos = null;
        [SerializeField] MMFeedbacks hitFeedback = null; 
        [Space]
        [SerializeField] SpriteRenderer spriteRenderer = null;

        [Header("DDEvent")]
        [SerializeField] DDEvent dungeonEnded = null;
        

        float healthPoints = 100f;
        bool isDead = false;

        InventoryHandler inventoryHandler;

        private void Awake() 
        {
            inventoryHandler = GetComponent<InventoryHandler>();    
        }

        private void Start() 
        {
            healthPoints = maxHealthPoints;    
        }

        public void TakeDamage(float damage)
        {
            hitFeedback.PlayFeedbacks();
            DamageText damageText = Instantiate(damageTextPrefab, floatingPos.position, Quaternion.identity);
            damageText.SetText(GetDamageToTake(damage));

            healthPoints = Mathf.Max(healthPoints - GetDamageToTake(damage), 0);
            if(healthPoints == 0)
            {
                Die();
            }
        }

        public void Heal(float heal)
        {
            healthPoints = Mathf.Min(healthPoints + heal, GetMaxHealthPoints());
        }

        void Die()
        {
            if(isDead) return;

            isDead = true;
            spriteRenderer.gameObject.SetActive(false);

            ActionObject actionObject = GetComponent<ActionObject>();
            if(actionObject != null) // Enemy
            {
                actionObject.EndActionWithThisObject();

                FindObjectOfType<Resource>().AddCoin(actionObject.GetComponent<Enemy>().dropCoin);
                // FindObjectOfType<FXMessage>().Show("적을 쓰러뜨렸다!");

                if(actionObject.CompareTag("Boss"))
                {
                    dungeonEnded.Occurred(this.gameObject); // Win
                }
                else
                {
                    Destroy(gameObject, 1f);
                }
            }    
            else // Player
            {
                dungeonEnded.Occurred(this.gameObject); // Lose

                // FindObjectOfType<FXMessage>().Show("전투에서 패배했다." + "\n" + "눈 앞이 캄캄해졌다...");
            }
        }

        public bool IsDead()
        {
            return isDead;
        }

        public float GetHealthPoints()
        {
            return healthPoints;
        }

        public float GetMaxHealthPoints()
        {
            if(inventoryHandler)
            {
                return maxHealthPoints + inventoryHandler.GetInventoryMaxHealth();
            }
            return maxHealthPoints;
        }

        public float GetDamageToTake(float damage)
        {
            float damageToTake;

            if(inventoryHandler) damageToTake = Mathf.Max(damage - inventoryHandler.GetInventoryArmor(), 1);
            else damageToTake = damage;

            return damageToTake;
        }
    }
}

