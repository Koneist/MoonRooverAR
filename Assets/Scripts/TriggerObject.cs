using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class TriggerObject : MonoBehaviour
    {
        protected delegate void EventHandler();
        protected event EventHandler OnCollisionEnterEvent;
        protected event EventHandler OnCollisionExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag != "Player")
                return;

            OnCollisionEnterEvent?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.tag != "Player")
                return;

            OnCollisionExitEvent?.Invoke();
        }

    }

}
