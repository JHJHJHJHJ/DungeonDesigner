using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;

public class GameManager : MonoBehaviour
{
    [SerializeField] ActionObject bossEnemy;
    [SerializeField] Transform bossSpawnPos = null;

    public void SpawnBoss()
    {
        Instantiate(bossEnemy, bossSpawnPos.position, Quaternion.identity);
    }
}
