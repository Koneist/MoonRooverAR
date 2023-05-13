using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRoverAr.Scripts.Vehicle
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private VehiclePhysics _vehiclePhysics;
        private GameInput _gameInput;

        [Header("Info")]
        [SerializeField] private Vector2 _input;
        [SerializeField] private float _acceleration;
        private void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
        }

        private void FixedUpdate()
        {
            _input = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

            _acceleration = _input.y >= 0 ? _input.magnitude : -_input.magnitude;

            _vehiclePhysics.Accelerate(_acceleration);
            _vehiclePhysics.Steer(_input.x);

        }
    }

}
