using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Core
{
    [CreateAssetMenu(fileName = "New DDEvent", menuName = "DungeonDesigner/DDEvent", order = 0)]
    public class DDEvent : ScriptableObject
    {
        List<DDEventListener> elisteners = new List<DDEventListener>();

        public void Register(DDEventListener listener)
        {
            elisteners.Add(listener);
        }

        public void Unregister(DDEventListener listener)
        {
            elisteners.Remove(listener);
        }

        public void Occurred()
        {
            for (int i = 0; i < elisteners.Count; i++)
            {
                elisteners[i].OnEventOccurs();
            }
        }
    }

}
