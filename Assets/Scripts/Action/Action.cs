using UnityEngine;
using DD.Object;

namespace DD.Action
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Handle(ActionObject target);

        public GameObject GetMyPlayer(ActionObject myObject) // override에서 사용
        {
            foreach (Transform child in myObject.transform.parent)
            {
                if (child.CompareTag("Player"))
                {
                    return child.gameObject;
                }
            }

            return null;
        }
    }
}
