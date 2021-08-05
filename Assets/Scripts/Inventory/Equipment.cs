using UnityEngine;

namespace DD.Inventory
{
    [CreateAssetMenu(fileName = "Equipment", menuName = "DungeonDesigner/Equipment", order = 0)]
    public class Equipment : ScriptableObject
    {
        public string myName;
        public Sprite sprite;
        [TextArea] public string description;
        public EquipStats equipStats;
    }

    [System.Serializable]
    public class EquipStats
    {
        public float damageUP;
        public float attackSpeedUP;
        public float armorUP;
        public float moveSpeedUP;
        public float maxHealthUP;


        public void Initialize()
        {
            damageUP = 0f;
            attackSpeedUP = 0f;
            armorUP = 0f;
            moveSpeedUP = 0f;
            maxHealthUP = 0f;
        }
    }
}
