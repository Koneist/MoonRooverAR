using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class CollectionObject : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ObjectVisualizator _visualizator;
        
        [SerializeField] private Sprite _objectImage;
        [SerializeField] private Sprite _lockedImage;
        [SerializeField] private Sprite _unlockedImage;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private bool _locked;
        public bool Locked
        {
            get 
            { 
                return _locked; 
            }
            set
            {
                //if(_locked == value)
                //    return;

                _locked = value;
                if (_locked)
                    _objectImage = _lockedImage;
                else
                    _objectImage = _unlockedImage;
            }
        }
        private void ShowObject()
        {
            var description = _description;
            if (Locked)
                description = "";
            _visualizator.Show(_name, _description, _objectImage);
        }

        public void Unlock() => Locked = false;

        private void Start()
        {
            //Locked = true;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ShowObject);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowObject);
        }
    }

}
