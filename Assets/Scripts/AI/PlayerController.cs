using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DD.Movement;
using DD.Combat;
using DD.Object;

namespace DD.AI
{
    public enum PlayerState
    {
        Idle, Interact
    }

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerState state;
        [SerializeField] float timeToIdle = 0.5f;

        Animator animator;
        AnimatorOverrideController overrideController;
        Fighter fighter;
        Mover mover;
        Health health;

        ActionObject currentTarget = null;
        float timeSinceIdle = Mathf.Infinity;

        bool isInteracting = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
        }

        private void Start()
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.down);
            state = PlayerState.Idle;
        }

        private void Update()
        {
            if (health.IsDead()) return;

            if (state == PlayerState.Idle)
            {
                isInteracting = false;

                if (timeSinceIdle >= timeToIdle)
                {
                    StartAction();
                }
                else
                {
                    timeSinceIdle += Time.deltaTime;
                }
            }
            else if (state == PlayerState.Interact)
            {
                if (currentTarget.type == ObjectType.enemy) return;

                if (!isInteracting)
                {
                    MoveToInteract();
                }

                // Fight와 다른 Action은 별도의 class에서에서 실행   
            }
        }

        public void StartAction()
        {
            currentTarget = FindCloseTarget();
            if (currentTarget == null) return;

            ObjectType targetType = currentTarget.type;
            if (targetType == ObjectType.enemy)
            {
                fighter.Attack(currentTarget.gameObject);
            }
            else
            {

            }

            state = PlayerState.Interact;
        }

        public ActionObject FindCloseTarget()
        {
            List<ActionObject> actionObjects = new List<ActionObject>();

            foreach (Transform child in transform.parent)
            {
                ActionObject actionObject = child.GetComponent<ActionObject>();
                if (actionObject != null)
                {
                    if (actionObject.CanInteract())
                    {
                        actionObjects.Add(actionObject);
                    }
                }
            }

            if (actionObjects.Count <= 0) return null;

            ActionObject closeTarget = null;
            float closeTargetDistance = 0f;

            for (int i = 0; i < actionObjects.Count; i++)
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

        void MoveToInteract()
        {
            if (!IsInRange())
            {
                mover.MoveTo(currentTarget.transform);
            }
            else
            {
                mover.Cancel();
                currentTarget.StartActionWithThisObject();
                isInteracting = true;
            }
        }

        public void GoToIdleState() // Event Listner에서 실행
        {
            currentTarget = null;
            timeSinceIdle = 0;

            state = PlayerState.Idle;
        }

        public void ReadyBossFight()
        {
            currentTarget = null;

            state = PlayerState.Idle;
        }

        bool IsInRange()
        {
            return Vector2.Distance(transform.position, currentTarget.transform.position) <= currentTarget.profile.interactRange;
        }
    }
}
