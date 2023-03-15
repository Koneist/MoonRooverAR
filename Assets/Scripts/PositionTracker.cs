using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class PositionTracker : MonoBehaviour
    {
        [SerializeField] private Transform _trackObject;
        [SerializeField] private Rigidbody _trackRigidbody;

        public Transform TrackObject
        {
            set 
            { 
                _trackObject = value;
                _trackRigidbody = _trackObject.GetComponent<Rigidbody>();
            }
        }
        private void Start()
        {
            _trackRigidbody= _trackObject.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            var temp = transform.position;
            temp.x -= _trackRigidbody.velocity.x * Time.deltaTime;
            temp.z -= _trackRigidbody.velocity.z * Time.deltaTime;
            transform.position = temp;
        }

        public void ChangePosition(Vector3 newPos)
        {
            var temp = transform.position;
            temp.x = -newPos.x;
            temp.z = -newPos.z;
            transform.position = temp;
            _trackRigidbody.velocity = Vector3.zero;

        }
    }

}
