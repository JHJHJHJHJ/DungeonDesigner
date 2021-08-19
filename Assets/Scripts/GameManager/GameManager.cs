using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.AI;
using DD.UI;
using DD.FX;

public class GameManager : MonoBehaviour
{
    [SerializeField] ActionObject bossEnemyPrefab;
    [SerializeField] Transform bossSpawnPos = null;

    private void Start() 
    {
        
    }

    public void SpawnBoss() // Event Listener에서 실행됨
    {
        EnemyController bossEnemy = Instantiate(bossEnemyPrefab, bossSpawnPos.position, Quaternion.identity).GetComponent<EnemyController>();
        bossEnemy.SetPlayer(FindObjectOfType<PlayerController>().gameObject);

        FindObjectOfType<BossTimerDisplay>().gameObject.SetActive(false);
    }
}
