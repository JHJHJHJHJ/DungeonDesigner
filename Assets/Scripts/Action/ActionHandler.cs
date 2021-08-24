using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Object;
using DD.Movement;

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
                GameObject myPlayer = GetMyPlayer(myObject);
                if(myPlayer == null) return;

                myPlayer.GetComponent<AnimatorOverrider>().UpdateAnimationClipByDirection(myObject.transform);
                
                action.Handle(myObject, myPlayer);
            }
        }

        GameObject GetMyPlayer(ActionObject myObject)
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

