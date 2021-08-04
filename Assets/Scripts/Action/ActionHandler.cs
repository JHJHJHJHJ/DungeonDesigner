using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;

namespace DD.Action
{
    public class ActionHandler : MonoBehaviour
    {
        [SerializeField] Action action;

        public void Interact() // Event Listner에서 실행
        {
            ActionObject myObject = GetComponent<ActionObject>();

            if (myObject.IsTarget())
            {
                action.Handle(myObject);
                Destroy(gameObject);
            }
        }
    }
}

