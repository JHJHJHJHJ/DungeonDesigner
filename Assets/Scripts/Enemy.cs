using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController overrideController;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        GetComponent<AnimatorOverrider>().SetAnimatorOverrider(Direction.up);    
    }

    private void Update() 
    {
        
    }
}
