using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController overrideController;

    bool isWalking = false;

    private void Awake() 
    {
        animator = GetComponent<Animator>();

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(overrideController, 0);
        }   
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(overrideController, 1);
        } 
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(overrideController, 2);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<AnimatorOverrider>().SetAnimatorOverrider(overrideController, 3);
        }
    }
}
