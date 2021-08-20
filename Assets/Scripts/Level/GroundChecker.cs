using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Level
{
    public class GroundChecker : MonoBehaviour
    {
        bool isOnGround = false;
        Transform currentObjectsParent = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                currentObjectsParent = other.GetComponent<Dungeon>().GetObjectsParent();
                isOnGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                currentObjectsParent = null;
                isOnGround = false;
            }
        }

        public bool IsOnGround()
        {
            return isOnGround;
        }

        public Transform GetCurrentObjectsParent()
        {
            return currentObjectsParent;
        }
    }

}
