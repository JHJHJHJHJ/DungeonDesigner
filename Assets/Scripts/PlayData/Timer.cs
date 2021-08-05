using UnityEngine;
using DD.Core;

namespace DD.PlayData
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] float timeToSpawnBoss = 120f;
        [SerializeField] DDEvent timerEnded = null;
        float timeSinceGameStart;

        bool hasEnded = false;

        private void Update() 
        {
            timeSinceGameStart += Time.deltaTime;

            if(!hasEnded)
            {
                if(timeSinceGameStart >= timeToSpawnBoss)
                {
                    timerEnded.Occurred();
                    hasEnded = true;
                }
            }
        }

        public float GetTimeToSpawnBoss()
        {
            return timeToSpawnBoss;
        }

        public float GetTimeSinceGameStart()
        {
            return timeSinceGameStart;
        }
    }
}
