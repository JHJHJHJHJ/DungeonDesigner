using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;
        [SerializeField] SpriteRenderer spriteRenderer = null;

        bool isDead = false;

        public void TakeDamage(float damage)
        {
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
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}

