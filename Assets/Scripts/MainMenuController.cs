using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoonRooverAR
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _collectionMenu;
        [SerializeField] private Collection _collection;
        [SerializeField] private GameObject _notification;

        void Start()
        {
            LoadCollection();
        }

        private void LoadCollection()
        {
            SaveManager.Instance.Load();
            var collection = SaveManager.Instance.State.CollectionLock;

            for (int i = 0; i < _collection.CollectionObjects.Length; ++i)
                _collection.CollectionObjects[i].Locked = collection[i];
        }

        public void LoadGame() => SceneManager.LoadScene(1);
        public void OpenCollectionMenu() => _collectionMenu.SetActive(true);
        public void CloseCollectionMenu() => _collectionMenu.SetActive(false);
        public void OpenNotification() => _notification.SetActive(true);
        public void CloseNotification() => _notification.SetActive(false);
        public void ClearPlayerData()
        {
            SaveManager.Instance.ClearData();
            CloseNotification();
        }

    }

}
