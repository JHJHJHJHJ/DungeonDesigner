using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Level
{
    public class GroundChecker : MonoBehaviour
    {
        bool isOnGround = false;
        Transform currentObjectsParent = null;
        int currentDungeonID = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                Dungeon currentDungeon = other.GetComponent<Dungeon>();
                currentObjectsParent = currentDungeon.GetObjectsParent();
                currentDungeonID = currentDungeon.dungeonID;

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

        public int GetCurrentDungeonID()
        {
            return currentDungeonID;
        }
    }

}
