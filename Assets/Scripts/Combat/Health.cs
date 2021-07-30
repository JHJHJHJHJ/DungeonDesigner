using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using DD.Action;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float MaxHealthPoints = 100f;
        [SerializeField] float healthPoints = 100f;
        [SerializeField] SpriteRenderer spriteRenderer = null;
        [SerializeField] MMFeedbacks hitFeedback = null; 
        [SerializeField] Event actionEnded;

        bool isDead = false;

        private void Start() 
        {
            healthPoints = MaxHealthPoints;    
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

        void Die()
        {
            if(isDead) return;

            isDead = true;
            spriteRenderer.gameObject.SetActive(false);

            ActionObject actionObject = GetComponent<ActionObject>();
            if(actionObject != null)
            {
                actionObject.SetCanInteract(false);
                actionEnded.Occurred();
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
            return MaxHealthPoints;
        }
    }
}

