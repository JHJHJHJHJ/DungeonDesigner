using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Action
{
    public class ActionObject : MonoBehaviour
    {
        [SerializeField] ObjectType type;

        public ObjectType GetObjectType()
        {
            return type;
        }
    }

    public enum ObjectType
    {
        enemy, item, bonfire
    }
}

