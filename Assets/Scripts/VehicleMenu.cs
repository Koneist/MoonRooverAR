using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class VehicleMenu : MonoBehaviour
    {

        [SerializeField] private GameObject _objectVisualizer;
        
        private void OnEnable()
        {
            _objectVisualizer.SetActive(false);
        }

    }

}
