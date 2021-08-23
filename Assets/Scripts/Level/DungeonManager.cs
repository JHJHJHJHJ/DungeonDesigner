using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Core;

namespace DD.Level
{
    public class DungeonManager : MonoBehaviour
    {
        [SerializeField] Dungeon[] dungeons = null;
        [SerializeField] DDEvent[] equipChanged = null;

        private void Start() {
            OpenDungeon(1);
            OpenDungeon(0);
            OpenDungeon(2);
        }

        void OpenDungeon(int index)
        {
            dungeons[index].gameObject.SetActive(true);
            dungeons[index].Initialzie();
        }

        void CloseDungeon(int index)
        {
            dungeons[index].Close();
        }
    }
}
