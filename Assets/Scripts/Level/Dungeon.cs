using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.PlayData;
using DD.UI;
using DD.Inventory;
using DD.Core;
using DD.AI;

namespace DD.Level
{
    public class Dungeon : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] GameObject playerPrefab = null;
        [SerializeField] ActionObject bossEnemyPrefab = null;

        [Header("Components")]
        [SerializeField] GameObject bossTimer = null;
        [SerializeField] HealthDisplay healthDisplay = null;
        [SerializeField] InventoryDisplay inventoryDisplay = null;

        [Header("Transforms")]
        [SerializeField] Transform objectsParent = null;
        [SerializeField] Transform playerSpawnPos = null;
        [SerializeField] Transform bossSpawnPos = null;

        GameObject currentPlayer;


        private void Start() 
        {
            
        }

        public void Initialzie()
        {
            currentPlayer = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity, objectsParent);

            inventoryDisplay.SetPlayer(currentPlayer);
            healthDisplay.SetPlayer(currentPlayer);
            
            bossTimer.GetComponent<Timer>().Reset();
        }

        public void Close()
        {
            foreach(Transform child in objectsParent)
            {
                Destroy(child.gameObject);
            }
            gameObject.SetActive(false);
        }

        public Transform GetObjectsParent()
        {
            return objectsParent;
        }

        public void SpawnBoss() // Event Listener에서 실행됨
        {
            foreach(Transform child in objectsParent)
            {
                if(child.CompareTag("Enemy")) Destroy(child.gameObject);                
            }

            currentPlayer.GetComponent<PlayerController>().GoToIdleState();

            Instantiate(bossEnemyPrefab, bossSpawnPos.position, Quaternion.identity, objectsParent);

            bossTimer.SetActive(false);
        }
    }
}

