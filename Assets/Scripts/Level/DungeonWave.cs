using UnityEngine;

namespace DD.Level
{
    [CreateAssetMenu(fileName = "DungeonWave", menuName = "DungeonDesigner/DungeonWave", order = 0)]
    public class DungeonWave : ScriptableObject
    {
        public WaveData[] waves = null;
    }

    [System.Serializable]
    public class WaveData
    {
        public int timeToWait;
        public DungeonToSpawn[] dungeonsToSpawn;
    }

    [System.Serializable]
    public class DungeonToSpawn
    {
        public GameObject playerToSpawn;
    }
}
