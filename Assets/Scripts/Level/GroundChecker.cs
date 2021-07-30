using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    bool isOnGround = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            isOnGround = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            isOnGround = false;
        }    
    }

    public bool IsOnGround()
    {
        return isOnGround;
    }
}
