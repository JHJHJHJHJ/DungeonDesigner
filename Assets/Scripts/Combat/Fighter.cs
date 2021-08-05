using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Movement;
using DD.Core;
using DD.Object;
using DD.FX;
using DD.Inventory;

namespace DD.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float damage = 10f;
        [SerializeField] float attackRange = 1f;
        [SerializeField] float timeBetweenAttack = 1f;

        Health target;
        float timeSinceLastAttack;
        Animator animator;
        AnimatorOverrider animatorOverrider;
        Mover mover;
        InventoryHandler inventoryHandler;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animatorOverrider = GetComponent<AnimatorOverrider>();
            mover = GetComponent<Mover>();
            inventoryHandler = GetComponent<InventoryHandler>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (GetComponent<Health>().IsDead() || target == null) return;

            if (!IsInRange())
            {
                mover.MoveTo(target.transform);
            }
            else
            {
                animator.SetBool("isFighting", true);
                mover.Cancel();
                AttackBehaviour();
            }
        }

        void AttackBehaviour()
        {
            if (target == null) return;

            animatorOverrider.UpdateAnimationClipByDirection(target.transform);

            if (timeSinceLastAttack >= GetTimeBetweenAttack())
            {
                // This will trigger 'Hit' event.
                animator.ResetTrigger("Attack");
                animator.SetTrigger("Attack");
                timeSinceLastAttack = 0;
            }
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;

            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();

            if (!target.CompareTag("Player"))
            {
                FindObjectOfType<FXMessage>().Show("전투를 시작했다!");
            }
        }

        bool IsInRange()
        {
            return (Vector2.Distance(transform.position, target.transform.position) <= attackRange);
        }

        public void Cancel()
        {
            target = null;
            animator.ResetTrigger("Attack");

            animator.SetBool("isFighting", false);
            timeSinceLastAttack = 0;

            GetComponent<Mover>().Cancel();
        }

        void Hit()
        {
            if (GetComponent<Health>().IsDead()) return;

            string message = "";
            if (target != null && !target.CompareTag("Player"))
            {
                message = "적에게 " + GetDamage() + " 데미지!";
            }
            else
            {
                message = target.GetDamageToTake(damage) + " 데미지를 입었다!";
            }
            FindObjectOfType<FXMessage>().Show(message);

            target.TakeDamage(GetDamage());

            if (target.IsDead()) Cancel();
        }

        float GetDamage()
        {
            if (inventoryHandler)
            {
                return damage + inventoryHandler.GetInventoryDamage();
            }

            return damage;
        }

        float GetTimeBetweenAttack()
        {
            if (inventoryHandler)
            {
                float modifier = 100f / (inventoryHandler.GetInventoryAttackSpeed() + 100f);
                return timeBetweenAttack * modifier;
            }

            return timeBetweenAttack;
        }
    }
}
