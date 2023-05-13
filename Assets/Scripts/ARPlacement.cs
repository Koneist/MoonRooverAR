using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static UnityEngine.InputSystem.InputAction;

namespace MoonRooverAR
{
    public class ARPlacement : MonoBehaviour
    {
        [SerializeField] private ARRaycastManager _raycastManager;
        [SerializeField] private GameObject _placementIndicator;
        [SerializeField] private GameObject _objectToSpawn;
        [SerializeField] private float _spawnOffset = 5f; 
        
        private GameInput _gameInput;
        private GameObject _spawnedObject;
        private Pose _placementPose;
        private bool _isPlacementPoseIsValid = false;
        private bool _isObjectPlased = false;


        private void Awake()
        {
            _gameInput = new GameInput();
            _objectToSpawn.SetActive(false);
        }

        private void OnEnable()
        {
            _gameInput.AR.Touch.performed += OnTouchPerformed;
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.AR.Touch.performed -= OnTouchPerformed;
            _gameInput.Disable();
        }

        private void OnApplicationPause(bool pause)
        {
            if (!pause)
                return;

            ResetPlacement();
        }

        private void ResetPlacement()
        {
            _placementIndicator.SetActive(true);
            _isObjectPlased = false;
            _objectToSpawn.SetActive(false);
            _gameInput.Enable();
        }

        private void OnTouchPerformed(CallbackContext context)
        {
            if (!_isPlacementPoseIsValid)
                return;

            PlaceObject();
        }

        private void Update()
        {
            if (_isObjectPlased || SaveManager.Instance.State.FirstSave)
                return;

            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }

        private void UpdatePlacementIndicator()
        {
            _placementIndicator.SetActive(_isPlacementPoseIsValid);

            if (!_isPlacementPoseIsValid)
                return;

            _placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
        }

        private void UpdatePlacementPose()
        {
            var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(.5f, .5f));
            var hits = new List<ARRaycastHit>();
            _raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

            _isPlacementPoseIsValid = hits.Count > 0;
            if (_isPlacementPoseIsValid)
                _placementPose = hits[0].pose;
        }

        private void PlaceObject()
        {
            var localpos = _placementPose.position;
            var localposOffset = localpos;
            localposOffset.Normalize();
            localposOffset.x = 0;
            localposOffset *= _spawnOffset;
            localpos += localposOffset;
            _objectToSpawn.transform.SetPositionAndRotation(localpos, _placementIndicator.transform.rotation);
            _objectToSpawn.SetActive(true);
            //_placementIndicator.SetActive(false);
            _isObjectPlased = true;
            _gameInput.Disable();
        }

    }

}
