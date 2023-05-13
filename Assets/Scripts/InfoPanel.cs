using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private Button _expandButton;
        [SerializeField] private Text _infoText;

        [SerializeField] private Collection _collection;
        [SerializeField] private CollectionMenu _collectionMenu;

        private Button _showButton;
        private CollectionObject _collectionObject;

        private void Awake()
        {
            _showButton = gameObject.GetComponent<Button>();
        }

        public void Show(int collectionId)
        {
            gameObject.SetActive(true);

            _collectionObject = _collection.CollectionObjects[collectionId];
            _showButton.onClick.AddListener(OnButtonClick);

            if (!_collectionObject.Locked)
            {
                _infoText.text = $"{_collectionObject.Name} уже был обнаружен.";
                return;
            }    

            _infoText.text = $"Вы обнаружили {_collectionObject.Name}.";
            
        }

        private void OnButtonClick()
        {
            _collectionMenu.Open();
            _collectionObject.ShowObject();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _infoText.text = "";
            _showButton.onClick.RemoveListener(OnButtonClick);
        }
    }

}
