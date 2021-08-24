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
        [SerializeField] Loading[] loadings = null;

        [Header("Wave")]
        [SerializeField] DungeonWave dungeonWave = null;

        [Header("Events")]
        [SerializeField] DDEvent[] equipChanged = null;

        private void Start() 
        {
            StartCoroutine(HandleWave());
        }

        IEnumerator HandleOpenDungeon(int index, GameObject playerToSpawn)
        {
            yield return StartCoroutine(HandleLoading(index));

            OpenDungeon(index, playerToSpawn);
        }

        IEnumerator HandleLoading(int index)
        {
            loadings[index].gameObject.SetActive(true);

            float timeSinceLoad = 0f;
            float timeToLoad = loadings[index].GetTimeToLoad();
            while(timeSinceLoad < timeToLoad)
            {
                float fillAmount = timeSinceLoad / timeToLoad;
                loadings[index].UpdateBar(fillAmount);

                timeSinceLoad = Mathf.Min(timeSinceLoad + Time.deltaTime, timeToLoad);

                yield return null;
            }

            yield return new WaitForSeconds(0.1f);

            loadings[index].gameObject.SetActive(false);
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
                    StartCoroutine(HandleOpenDungeon(GetIndexToOpen(), dungeonToSpawn.playerToSpawn));
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
                }
            }

            int index = closedDungeonIndexList[Random.Range(0, closedDungeonIndexList.Count)];

            return index;
        }
    }
}
