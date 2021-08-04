using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using DD.Object;
using DD.PlayState;
using DD.Core;
using DD.FX;
using DD.Inventory;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealthPoints = 100f;
        [SerializeField] float healthPoints = 100f;
        [SerializeField] SpriteRenderer spriteRenderer = null;
        [SerializeField] MMFeedbacks hitFeedback = null; 

        bool isDead = false;

        private void Start() 
        {
            healthPoints = maxHealthPoints;    
        }

        public void TakeDamage(float damage)
        {
            hitFeedback.PlayFeedbacks();

            InventoryHandler inventoryHandler = GetComponent<InventoryHandler>();
            float damageToTake;
            if(inventoryHandler) damageToTake = Mathf.Max(damage - inventoryHandler.GetInventoryArmor(), 1);
            else damageToTake = damage;

            healthPoints = Mathf.Max(healthPoints - damageToTake, 0);
            if(healthPoints == 0)
            {
                Die();
            }
        }

        public void Heal(float heal)
        {
            healthPoints = Mathf.Min(healthPoints + heal, maxHealthPoints);
        }

        void Die()
        {
            if(isDead) return;

            isDead = true;
            spriteRenderer.gameObject.SetActive(false);

            ActionObject actionObject = GetComponent<ActionObject>();
            if(actionObject != null)
            {
                actionObject.EndActionWithThisObject();

                FindObjectOfType<PlayData>().AddCoin(actionObject.GetComponent<Enemy>().dropCoin);
                FindObjectOfType<FXMessage>().Show("적을 쓰러뜨렸다!");

                Destroy(gameObject, 1f);
            }    
            else
            {
                FindObjectOfType<FXMessage>().Show("전투에서 패배했다." + "\n" + "눈 앞이 캄캄해졌다...");
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
            return maxHealthPoints;
        }
    }
}

