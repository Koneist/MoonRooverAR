using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class CollectableObject : TriggerObject
    {
        [SerializeField] private InfoPanel _infoPanel;
        [SerializeField] private int _collectionId;
        [SerializeField] private Collection _collection;

        private void OnEnable()
        {
            OnCollisionEnterEvent += ShowInfoPanel;
            OnCollisionExitEvent += _infoPanel.Hide;
        }

        private void OnDisable()
        {
            OnCollisionEnterEvent -= ShowInfoPanel;
            OnCollisionExitEvent -= _infoPanel.Hide;
        }

        private void ShowInfoPanel()
        {
            _collection.Unlock(_collectionId);
            _infoPanel.Show(_collectionId);
        }
    }

}
