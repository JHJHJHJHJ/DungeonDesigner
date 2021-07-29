using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DD.Movement;
using DD.Combat;
using DD.Action;
using System.Linq;

namespace DD.AI
{
    public class PlayerController : MonoBehaviour
    {
        Animator animator;
        AnimatorOverrideController overrideController;

        Fighter fighter;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
        }

        private void Start()
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.down);
            StartAction();
        }

        private void Update()
        {
        }

        public void StartAction()
        {
            ActionObject target = FindCloseTarget();
            if (target == null) return;

            ObjectType targetType = target.GetObjectType();

            if (targetType == ObjectType.enemy)
            {
                fighter.Attack(target);
            }
        }

        public ActionObject FindCloseTarget()
        {
            ActionObject[] actionObjects = FindObjectsOfType<ActionObject>();

            ActionObject closeTarget = null;
            float closeTargetDistance = 0f;

            for (int i = 0; i < actionObjects.Length; i++)
            {
                float distanceToObject = Vector2.Distance(transform.position, actionObjects[i].transform.position);

                if (i == 0 || closeTargetDistance >= distanceToObject)
                {
                    closeTarget = actionObjects[i];
                    closeTargetDistance = distanceToObject;
                }
            }

            return closeTarget;
        }
    }
}
