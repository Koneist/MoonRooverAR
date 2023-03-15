using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class VehicleMenuVisualizator : MonoBehaviour
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

        public void Show(VehicleInfo info)
        {
            _name.text = info.Name;
            _description.text = info.Description;
            //_image.sprite = image;
        }
    }
}

