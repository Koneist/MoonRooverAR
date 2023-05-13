using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoonRooverAR
{
    public class CollectionMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _objectVisualizer;
        [SerializeField] private MenuController _menuController;
        private void OnEnable()
        {
            _objectVisualizer.SetActive(false);
        }

        public void Open()
        {
            _menuController.ShowMenu();
            _menuController.ShowCollectionMenu();
        }
    }

}
