using UnityEngine;

namespace DD.Object
{
    [CreateAssetMenu(fileName = "new Profile", menuName = "DungeonDesigner/Object Profile", order = 0)]
    public class ObjectProfile : ScriptableObject
    {
        public string myName = null;
        public Sprite repSprite = null;
        public int cost;
        public float interactRange = 0.3f; // not for enemy
    }
}
