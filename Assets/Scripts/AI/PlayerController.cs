using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DD.Movement;
using DD.Combat;
using DD.Action;

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

        ActionObject currentTarget = null;
        float timeSinceIdle = Mathf.Infinity;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
        }

        private void Start()
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.down);
            state = PlayerState.Idle;
        }

        private void Update()
        {
            if(state == PlayerState.Idle)
            {
                if(timeSinceIdle >= timeToIdle)
                {
                    StartAction();
                }
                else
                {
                    timeSinceIdle += Time.deltaTime;
                }
            }
            else if(state == PlayerState.Interact)
            {

            }
        }

        public void StartAction()
        {
            currentTarget = FindCloseTarget();
            if (currentTarget == null) return;

            ObjectType targetType = currentTarget.GetObjectType();
            if (targetType == ObjectType.enemy)
            {
                fighter.Attack(currentTarget.gameObject);
            }

            state = PlayerState.Interact;
        }

        public ActionObject FindCloseTarget()
        {
            List<ActionObject> actionObjects = new List<ActionObject>();
            foreach(ActionObject actionObject in FindObjectsOfType<ActionObject>())
            {
                if(actionObject.CanInteract())
                {
                    actionObjects.Add(actionObject);
                }
            }

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

        public void GoToIdle()
        {
            currentTarget = null;
            timeSinceIdle = 0;
            state = PlayerState.Idle;
        }
    }
}
