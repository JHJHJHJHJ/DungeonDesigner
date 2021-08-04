using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DD.Core
{
    public class DDEventListener : MonoBehaviour
    {
        public DDEvent gEvent;
        public UnityEvent response;

        private void OnEnable()
        {
            gEvent.Register(this);
        }

        private void OnDisable()
        {
            gEvent.Unregister(this);
        }

        public void OnEventOccurs()
        {
            response.Invoke();
        }
    }

}
