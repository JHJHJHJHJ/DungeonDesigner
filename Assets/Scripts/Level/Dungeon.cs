using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;

namespace DD.Level
{
    public class Dungeon : MonoBehaviour
    {
        [SerializeField] ActionObject bossEnemyPrefab;
        [SerializeField] Transform bossSpawnPos = null;
        [SerializeField] Transform objectsParent = null;
        [SerializeField] GameObject bossTimer = null;

        private void Start() 
        {
            
        }

        public Transform GetObjectsParent()
        {
            return objectsParent;
        }

        public void SpawnBoss() // Event Listener에서 실행됨
        {
            Instantiate(bossEnemyPrefab, bossSpawnPos.position, Quaternion.identity, objectsParent);

            bossTimer.SetActive(false);
        }
    }
}

