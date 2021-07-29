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
    }
}


public enum Direction
{
    up = 0, right = 1, down = 2, left = 3
}
