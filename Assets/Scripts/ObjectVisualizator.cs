using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class ObjectVisualizator : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Image _image;
        [SerializeField] private Text _description;

        private Color32 _lockedColor = new Color32(10, 10, 10,255);
        private Color32 _unlockedColor = new Color32(250, 255, 255, 255);

        private void Start()
        {

        }

        public void Clear()
        {
            _name.text = "";
            _description.text = "";
            _image.sprite = null;
        }

        public void Show(string name, string description, Sprite image, bool IsLocked)
        {
            
            _name.text = name;
            _image.sprite = image;
            if (IsLocked) 
            {
                _image.color = _lockedColor;
                _description.text = "Этот предмет еще не разблокирован";
                
                gameObject.SetActive(true);
                return;
            }

            _image.color = _unlockedColor;
            _description.text = description;

            gameObject.SetActive(true);
        }
    }
}
