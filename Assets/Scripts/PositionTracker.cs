using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class PositionTracker : MonoBehaviour
    {
        [SerializeField] private Transform _trackObject;
        [SerializeField] private Rigidbody _trackRigidbody;
        [SerializeField] private Material[] _clippingMaterials;
        [SerializeField] private float _materialRadius = 2;
        [SerializeField] private bool _resetOnExit;

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
            InitializeClippingMaterial(_trackObject.transform.position, _materialRadius);
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            var temp = transform.localPosition;
            //temp.x -= _trackRigidbody.velocity.x * Time.deltaTime;
            //temp.z -= _trackRigidbody.velocity.z * Time.deltaTime;
            //temp.y -= _trackRigidbody.velocity.y * Time.deltaTime;
            temp -= _trackRigidbody.velocity * Time.deltaTime;
            transform.localPosition = temp;
        }

        public void ChangePosition(Vector3 newPos)
        {
            //var temp = transform.position;
            //temp.x = -newPos.x;
            //temp.z = -newPos.z;
            transform.localPosition = -newPos;
            _trackRigidbody.velocity = Vector3.zero;

        }

        private void OnApplicationQuit()
        {
            if(_resetOnExit)
            {
                InitializeClippingMaterial(Vector3.zero, 250);
                return;
            }

            InitializeClippingMaterial(Vector3.zero, _materialRadius);
        }

        private void InitializeClippingMaterial(Vector3 center, float radius)
        {
            foreach (var material in _clippingMaterials)
            {
                material.SetVector("_CentralSpot", center);
                material.SetFloat("_Radius", radius);
            }
        }
    }

}
