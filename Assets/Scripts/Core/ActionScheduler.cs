using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                action.Cancel();
            }

            currentAction = action;
        }
    }
}

