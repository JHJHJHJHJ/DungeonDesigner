using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Movement
{
    public class AnimatorOverrider : MonoBehaviour
    {
        [Header("* 0:U 1:R 2:D 3:L")]
        [SerializeField] AnimationClip[] idleClips;
        [SerializeField] AnimationClip[] walkClips;
        [SerializeField] AnimationClip[] fightClips;
        [SerializeField] AnimationClip[] attackClips;

        Animator animator;
        AnimatorOverrideController overrideController;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrideController;
        }

        public void SetAnimatorOverrider(Direction direction)
        {
            overrideController["Idle"] = idleClips[(int)direction];
            overrideController["Walk"] = walkClips[(int)direction];
            overrideController["Fight"] = fightClips[(int)direction];
            overrideController["Attack"] = attackClips[(int)direction];
        }

        public void UpdateAnimationClipByDirection(Transform target)
        {
            Vector3 lookDirection = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
            lookDirection = Vector3.Normalize(lookDirection);

            if (lookDirection.x < -0.5)
            {
                SetAnimatorOverrider(Direction.left);
            }
            else if (lookDirection.x > 0.5)
            {
                SetAnimatorOverrider(Direction.right);
            }
            else
            {
                if (lookDirection.y >= 0)
                {
                    SetAnimatorOverrider(Direction.up);
                }
                else
                {
                    SetAnimatorOverrider(Direction.down);
                }
            }
        }
    }
}


public enum Direction
{
    up = 0, right = 1, down = 2, left = 3
}
