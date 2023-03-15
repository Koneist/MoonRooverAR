using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MoonRooverAR
{
    public class VehicleAttacher : MonoBehaviour
    {
        [SerializeField] private GameObject _vehicle;
        [SerializeField] private PositionTracker _tracker;
        public GameObject Vehicle { get => _vehicle; }

        public void Attach(GameObject vehicle, Vector3 position)
        {
            _vehicle = vehicle;
            _tracker.TrackObject = vehicle.transform;
            _tracker.ChangePosition(position);
        }

        public void ChangeVehicle(GameObject vehicle)
        {
            var pos = _vehicle.transform.position;
            var rotation = _vehicle.transform.rotation;
            var parent = _vehicle.transform.parent;
            var size = _vehicle.transform.localScale;

            _vehicle.SetActive(false);
            
            Destroy(_vehicle, 0);

            _vehicle = Instantiate(vehicle, pos, rotation, parent);
            _vehicle.transform.localScale = size;
            Attach(_vehicle, pos);
            

        }
    }

}
