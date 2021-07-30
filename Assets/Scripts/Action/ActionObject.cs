using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Action
{
    public class ActionObject : MonoBehaviour
    {
        [SerializeField] ObjectType type;
        [SerializeField] int cost;

        bool canInteract = true;

        public ObjectType GetObjectType()
        {
            return type;
        }

        public bool CanInteract()
        {
            return canInteract;
        }

        public void SetCanInteract(bool tf)
        {
            canInteract = tf;
        }
    }

    public enum ObjectType
    {
        enemy, item, bonfire
    }
}

