using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Core;
using DD.Inventory;

namespace DD.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform destination;

        [SerializeField] float speed;

        Animator animator;
        AnimatorOverrideController overrideController;
        AnimatorOverrider animatorOverrider;
        InventoryHandler inventoryHandler;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animatorOverrider = GetComponent<AnimatorOverrider>();
            inventoryHandler = GetComponent<InventoryHandler>();
        }

        private void Update()
        {
            Move();
            Arrive();
        }

        void Arrive()
        {
            if (destination != null && transform.position == destination.position)
            {
                Cancel();
            }
        }

        public void StartMoveAction(Transform destinationToSet)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destinationToSet);
        }

        public void MoveTo(Transform destinationToSet)
        {
            animator.SetBool("isWalking", true);
            destination = destinationToSet;
        }

        public void Move()
        {
            if (destination == null) return;

            animatorOverrider.UpdateAnimationClipByDirection(destination);
            transform.position = Vector2.MoveTowards(transform.position, destination.position, GetMoveSpeed() * Time.deltaTime);
        }

        public void Cancel()
        {
            destination = null;
            animator.SetBool("isWalking", false);
        }

        float GetMoveSpeed()
        {
            if(inventoryHandler)
            {
                return speed * (100f + inventoryHandler.GetInventorymoveSpeed()) / 100f;
            }
            return speed;
        }
    }
}

