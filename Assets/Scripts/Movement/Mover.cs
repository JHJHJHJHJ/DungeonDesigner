using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Core;

namespace DD.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform destination;

        [SerializeField] float speed;

        Animator animator;
        AnimatorOverrideController overrideController;
        AnimatorOverrider animatorOverrider;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animatorOverrider = GetComponent<AnimatorOverrider>();
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
            transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }

        public void Cancel()
        {
            destination = null;
            animator.SetBool("isWalking", false);
        }
    }
}

