using UnityEngine;

namespace DD.Inventory
{
    [CreateAssetMenu(fileName = "Equipment", menuName = "DungeonDesigner/Equipment", order = 0)]
    public class Equipment : ScriptableObject
    {
        [SerializeField] string myName;
        [SerializeField] Sprite sprite;
        [SerializeField] [TextArea] string description;
        public EquipStats equipStats;
    }

    [System.Serializable]
    public class EquipStats
    {
        public float damage;
        public float attackSpeed;
        public float armor;
        public float moveSpeed;


        public void Initialize()
        {
            damage = 0f;
            attackSpeed = 0f;
            armor = 0f;
            moveSpeed = 0f;
        }
    }
}
