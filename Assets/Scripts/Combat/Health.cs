using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using DD.Object;
using DD.PlayState;
using DD.Core;

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
            healthPoints = Mathf.Max(healthPoints - damage, 0);
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

                Destroy(gameObject, 1f);
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

