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

        private void Start()
        {
            Hide();
        }

        public void Hide()
        {
            _name.text = "";
            _description.text = "";
            _image.sprite = null;
        }

        public void Show(string name, string description, Sprite image)
        {
            _name.text = name;
            _description.text = description;
            _image.sprite = image;
        }
    }
}
