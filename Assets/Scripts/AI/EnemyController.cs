using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Movement;
using DD.Combat;
using DD.Object;

namespace DD.AI
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 1f;

        Animator animator;
        AnimatorOverrideController overrideController;
        Fighter fighter;
        ActionObject actionObject;

        GameObject player;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
            actionObject = GetComponent<ActionObject>();
        }

        private void Start()
        {
            // player = GameObject.FindGameObjectWithTag("Player");
            // GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.up);
        }

        private void Update()
        {
            if(!actionObject.CanInteract()) return;

            if(InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }   

        private void OnDrawGizmos() 
        {
            Gizmos.DrawWireSphere(transform.position, chaseDistance);    
        }

        bool InAttackRangeOfPlayer()
        {
            if(player.GetComponent<Health>().IsDead()) return false;
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            return distanceToPlayer <= chaseDistance;
        }

        public void SetPlayer(GameObject player)
        {
            this.player = player;
        }
    }
}

