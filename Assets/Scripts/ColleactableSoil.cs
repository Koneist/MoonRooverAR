using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class ColleactableSoil : TriggerObject
    {
        [SerializeField] private Button _collectButton;
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private int _collectionId;
        [SerializeField] private Collection _collection;

        private void OnEnable()
        {
            OnCollisionEnterEvent += EnableButton;
            OnCollisionExitEvent += DisableButton;
        }

        private void OnDisable()
        {
            OnCollisionEnterEvent -= EnableButton;
            OnCollisionExitEvent -= DisableButton;
        }

        private void CollectSoil()
        {
            _infoPanel.Show(gameObject);
            _collection.Unlock(_collectionId);
        }

        private void EnableButton()
        {
            _collectButton.interactable = true;
            _collectButton.onClick.AddListener(CollectSoil);
        }

        private void DisableButton()
        {
            _collectButton.interactable = false;
            _collectButton.onClick.RemoveListener(CollectSoil);
        }
    }

}
