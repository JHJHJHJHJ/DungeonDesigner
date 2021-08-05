using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.AI;
using DD.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] ActionObject bossEnemyPrefab;
    [SerializeField] Transform bossSpawnPos = null;

    public void SpawnBoss()
    {
        EnemyController bossEnemy = Instantiate(bossEnemyPrefab, bossSpawnPos.position, Quaternion.identity).GetComponent<EnemyController>();
        bossEnemy.SetPlayer(FindObjectOfType<PlayerController>().gameObject);

        FindObjectOfType<BossTimerDisplay>().gameObject.SetActive(false);
    }
}
