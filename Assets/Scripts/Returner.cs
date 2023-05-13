using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class Returner : MonoBehaviour
    {
        [SerializeField] private Vector3 _returnPosition;
        [SerializeField] private VehicleAttacher _attacher;
        [SerializeField] private PositionTracker _traker;

        public void Return()
        {
            _attacher.Vehicle.transform.localPosition = _returnPosition;
            _attacher.Vehicle.transform.rotation = Quaternion.identity;
            //_attacher.Vehicle.GetComponent<Rigidbody>().position = _returnPosition;
            _traker.ChangePosition(_returnPosition);
        }

    }

}
