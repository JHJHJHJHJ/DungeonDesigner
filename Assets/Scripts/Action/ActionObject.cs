using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Object
{
    public class ActionObject : MonoBehaviour
    {
        public ObjectType type;
        public ObjectProfile profile;
        [SerializeField] Event actionEnded;

        bool canInteract = true;

        public bool CanInteract()
        {
            return canInteract;
        }

        public void SetCanInteract(bool tf)
        {
            canInteract = tf;
        }

        public void Interact()
        {
            print("interacting...");
            Destroy(gameObject);
            actionEnded.Occurred();
        }
    }

    public enum ObjectType
    {
        enemy, item, bonfire
    }
}

