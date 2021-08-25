using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.PlayData;
using DD.Inventory;
using DD.Core;
using DD.FX;

namespace DD.Level
{
    public class Dungeon : MonoBehaviour
    {
        public int dungeonID = 0;

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

        [Header("Events")]
        [SerializeField] DDEvent getResult = null;

        GameObject currentPlayer;
        BoxCollider2D boxCollider2D;

        private void Awake() 
        {
            boxCollider2D = GetComponent<BoxCollider2D>();    
        }

        public void Initialzie(GameObject playerToSpawn)
        {
            currentPlayer = Instantiate(playerToSpawn, playerSpawnPos.position, Quaternion.identity, objectsParent);
            currentPlayer.GetComponent<InventoryHandler>().dungeonID = dungeonID;

            inventoryDisplay.SetPlayer(currentPlayer);
            healthDisplay.SetPlayer(currentPlayer);
            
            bossTimer.SetActive(true);
            bossTimer.GetComponent<Timer>().Reset();

            boxCollider2D.enabled = true;

            FXMessage.ShowMessage("김 똘똘이(가) 접속했다!", dungeonID);
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

            FXMessage.ShowMessage("보스몬스터 등장!", dungeonID);

            bossTimer.SetActive(false);
        }

        public void StartDungeonEnd(GameObject deadObject) // Event Listener에서 실행됨
        {
            if(deadObject.transform.parent != objectsParent) return;
        
            StartCoroutine(HandleDungeonEnd(deadObject));
        }

        IEnumerator HandleDungeonEnd(GameObject deathObject) // TODO: 나중에 정리
        {
            boxCollider2D.enabled = false;

            string endMessage = "";
            bool hasWon = true;

            if(deathObject.CompareTag("Boss"))
            {
                endMessage = "보스몬스터를 쓰러뜨렸다.\n던전 클리어!";
            }
            else if(deathObject.CompareTag("Player"))
            {
                endMessage = "전투에서 패배했다.\n눈 앞이 깜깜해졌다...";
                hasWon = false;
            }

            FXMessage.ShowMessage(endMessage, dungeonID);
            yield return new WaitForSeconds(1.5f);

            PlayerReaction playerReaction = currentPlayer.GetComponent<PlayerReaction>();

            if(hasWon)
            {
                yield return StartCoroutine(playerReaction.ChatAboutWin(1f));
            }
            else
            {
                yield return StartCoroutine(playerReaction.ChatAboutLose(1f));
            }

            playerReaction.ShowReview(hasWon);
            yield return new WaitForSeconds(1.5f);
        
            getResult.Occurred(deathObject);
            Close();
        }
    }
}

