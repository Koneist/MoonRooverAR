using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace MoonRooverAR
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _collectionMenu;
        [SerializeField] private GameObject _SelectVehicleMenu;
        [SerializeField] private GameObject _SelectVehicleMenuCloseButton;
        [SerializeField] private SaveController _saveController;

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
            _saveController.Save();
            ResumeGame();
            SceneManager.LoadScene(0);
        }

        public void PauseGame() => Time.timeScale = 0.0f;
        public void ResumeGame() => Time.timeScale = 1.0f;
        public void ShowCollectionMenu() => _collectionMenu.SetActive(true);
        public void CloseCollectionMenu() => _collectionMenu.SetActive(false);
        public void ShowSelectVehicleMenu(bool isFirstTime = false)
        {
            _SelectVehicleMenu.SetActive(true);
            _SelectVehicleMenuCloseButton.SetActive(!isFirstTime);
        }
        public void CloseSelectVehicleMenu() => _SelectVehicleMenu.SetActive(false);

    }
}
