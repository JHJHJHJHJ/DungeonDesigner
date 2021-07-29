using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Movement;
using DD.Core;
using DD.Action;

namespace DD.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float damage = 10f;
        [SerializeField] float attackRange = 1f;
        [SerializeField] float timeBetweenAttack = 1f;

        [SerializeField] Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        Animator animator;

        private void Awake() 
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!IsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform);
            }
            else
            {
                animator.SetBool("isFighting", true);
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        void AttackBehaviour()
        {
            if(timeSinceLastAttack >= timeBetweenAttack)
            {
                // This will trigger 'Hit' event.
                animator.SetTrigger("Attack");
                timeSinceLastAttack = 0;
            }
        }

        public void Attack(ActionObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        bool IsInRange()
        {
            return (Vector2.Distance(transform.position, target.transform.position) <= attackRange);
        }

        public void Cancel()
        {
            animator.SetBool("isFighting", false);
            target = null;
        }

        void Hit()
        {
            target.TakeDamage(damage);
            if(target.IsDead()) Cancel();
        } 
    }
}
