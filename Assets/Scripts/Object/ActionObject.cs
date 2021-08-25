using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Core;

namespace DD.Object
{
    public class ActionObject : MonoBehaviour
    {
        public int dungeonID = 0;

        [Header("Configs")]
        public ObjectType type;
        public ObjectProfile profile;

        [Header("Event")]
        [SerializeField] DDEvent actionStarted;
        [SerializeField] DDEvent actionEnded;

        // Status
        bool canInteract = true;
        bool isTarget = false;

        private void Start() 
        {
            canInteract = true;
            isTarget = false;    
        }

        public bool CanInteract()
        {
            return canInteract;
        }

        public void SetCanInteract(bool tf)
        {
            canInteract = tf;
        }

        public bool IsTarget()
        {
            return isTarget;
        }

        public void SetTarget(bool tf)
        {
            isTarget = tf;
        }

        public void StartActionWithThisObject()
        {
            SetTarget(true);
            actionStarted.Occurred(this.gameObject);
        }

        public void EndActionWithThisObject()
        {
            SetCanInteract(false);
            SetTarget(false);
            actionEnded.Occurred(this.gameObject);
        }
    }

    public enum ObjectType
    {
        enemy, item, bonfire
    }
}

