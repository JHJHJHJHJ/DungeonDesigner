using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Core;

namespace DD.Level
{
    public class DungeonManager : MonoBehaviour
    {
        [Header("Dungeon Instance")]
        [SerializeField] Dungeon[] dungeons = null;

        [Header("Wave")]
        [SerializeField] DungeonWave dungeonWave = null;

        [Header("Events")]
        [SerializeField] DDEvent[] equipChanged = null;

        private void Start() 
        {
            StartCoroutine(HandleWave());
        }

        void OpenDungeon(int index, GameObject playerToSpawn)
        {
            dungeons[index].gameObject.SetActive(true);
            dungeons[index].Initialzie(playerToSpawn);
        }

        void CloseDungeon(int index)
        {
            dungeons[index].Close();
        }

        IEnumerator HandleWave()
        {
            foreach(WaveData wave in dungeonWave.waves)
            {
                yield return new WaitForSeconds(wave.timeToWait);

                foreach(DungeonToSpawn dungeonToSpawn in wave.dungeonsToSpawn)
                {
                    OpenDungeon(GetIndexToOpen(), dungeonToSpawn.playerToSpawn);
                }
            }
        }

        int GetIndexToOpen()
        {
            List<int> closedDungeonIndexList = new List<int>();
            for (int i = 0; i < dungeons.Length; i++)
            {
                if (!dungeons[i].gameObject.activeSelf)
                {
                    closedDungeonIndexList.Add(i);
                    print(i);
                }
            }

            int index = closedDungeonIndexList[Random.Range(0, closedDungeonIndexList.Count)];

            return index;
        }
    }
}
