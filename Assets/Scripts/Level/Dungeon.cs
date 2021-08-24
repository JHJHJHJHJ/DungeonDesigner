using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.PlayData;
using DD.Inventory;
using DD.Core;
using DD.AI;

namespace DD.Level
{
    public class Dungeon : MonoBehaviour
    {
        [Header("Prefabs")]
        // [SerializeField] GameObject playerPrefab = null;
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

        public void Initialzie(GameObject playerToSpawn)
        {
            currentPlayer = Instantiate(playerToSpawn, playerSpawnPos.position, Quaternion.identity, objectsParent);

            inventoryDisplay.SetPlayer(currentPlayer);
            healthDisplay.SetPlayer(currentPlayer);
            
            bossTimer.SetActive(true);
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

        public void SpawnBoss(GameObject endedTimer) // Event Listener에서 실행됨
        {
            if(endedTimer != bossTimer) return;

            // currentPlayer.GetComponent<PlayerController>().ReadyBossFight();

            // foreach(Transform child in objectsParent)
            // {
            //     if(child.CompareTag("Enemy")) Destroy(child.gameObject);                
            // }

            ActionObject boss = Instantiate(bossEnemyPrefab, bossSpawnPos.position, Quaternion.identity, objectsParent);

            bossTimer.SetActive(false);
        }

        public void HandleDungeonEnd(GameObject deathObject) // Event Listener에서 실행됨
        {
            if(deathObject.transform.parent != objectsParent) return;

            if(deathObject.CompareTag("Boss"))
            {
                FindObjectOfType<Result>().AddLike();
            }
            else if(deathObject.CompareTag("Player"))
            {
                FindObjectOfType<Result>().AddDislike();
            }

            Close();
        }
    }
}

