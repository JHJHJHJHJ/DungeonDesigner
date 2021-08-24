using UnityEngine;
using DD.Object;

namespace DD.Action
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Handle(ActionObject target, GameObject player);
    }
}
