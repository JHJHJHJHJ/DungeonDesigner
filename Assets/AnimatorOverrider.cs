using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    [Header("* 0:U 1:R 2:D 3:L")]
    [SerializeField] AnimationClip[] idleClips;
    [SerializeField] AnimationClip[] walkClips;

    public void SetAnimatorOverrider(AnimatorOverrideController overrideController, int i)
    {
        overrideController["Idle"] = idleClips[i];
        overrideController["Walk"] = walkClips[i];
    }
}
