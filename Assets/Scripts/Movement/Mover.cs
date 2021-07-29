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

        private void Start()
        {
        }

        private void Update()
        {
            Move();
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

            UpdateAnimationClipByDirection();
            transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }

        public void Cancel()
        {
            destination = null;
            animator.SetBool("isWalking", false);
        }

        void UpdateAnimationClipByDirection()
        {
            Vector3 moveDirection = new Vector3(destination.position.x - transform.position.x, destination.position.y - transform.position.y, 0);
            moveDirection = Vector3.Normalize(moveDirection);

            if (moveDirection.x < -0.5)
            {
                animatorOverrider.SetAnimatorOverrider(Direction.left);
            }
            else if (moveDirection.x > 0.5)
            {
                animatorOverrider.SetAnimatorOverrider(Direction.right);
            }
            else
            {
                if (moveDirection.y >= 0)
                {
                    animatorOverrider.SetAnimatorOverrider(Direction.up);
                }
                else
                {
                    animatorOverrider.SetAnimatorOverrider(Direction.down);
                }
            }
        }
    }
}

