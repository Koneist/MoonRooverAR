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
        [SerializeField] private Image _previewImage;

        [SerializeField] private Sprite _objectSprite;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private bool _locked;

        private Color32 _lockedColor = new Color32(10, 10, 10, 255);
        private Color32 _unlockedColor = new Color32(250, 255, 255, 255);

        public Sprite ObjectSprite { get => _objectSprite; }
        public string Name { get => _name; }
        public string Description { get => _description; }

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
                    _previewImage.color = _lockedColor;
                else
                    _previewImage.color = _unlockedColor;
            }
        }
        public void ShowObject()
        {
            _visualizator.Show(_name, _description, _objectSprite, Locked);
        }

        public void Unlock() => Locked = false;

        private void Start()
        {
            _previewImage.sprite = _objectSprite;
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
