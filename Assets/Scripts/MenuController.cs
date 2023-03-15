using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _collectionMenu;
        [SerializeField] private GameObject _SelectVehicleMenu;

        public void ShowMenu()
        {
            PauseGame();
            gameObject.SetActive(true);
        }
        public void CloseMenu()
        {
            ResumeGame();
            gameObject.SetActive(false);
        }
        public void MainMenuReturn()
        {

        }
        public void PauseGame() => Time.timeScale = 0.0f;
        public void ResumeGame() => Time.timeScale = 1.0f;
        public void ShowCollectionMenu() => _collectionMenu.SetActive(true);
        public void CloseCollectionMenu() => _collectionMenu.SetActive(false);
        public void ShowSelectVehicleMenu() => _SelectVehicleMenu.SetActive(true);
        public void CloseSelectVehicleMenu() => _SelectVehicleMenu.SetActive(false);

    }
}
