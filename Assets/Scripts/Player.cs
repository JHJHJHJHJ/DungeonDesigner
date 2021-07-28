using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController overrideController;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.down);    
    }

    private void Update() 
    {
    }
}
