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
        [SerializeField] private Vector2 input;
        [SerializeField] private float accelerationPedal;
        private void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
        }

        private void FixedUpdate()
        {
            var inputVector = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
            input = inputVector;
            _vehiclePhysics.Accelerate(input.y);
            _vehiclePhysics.Steer(input.x);

        }
    }

}
