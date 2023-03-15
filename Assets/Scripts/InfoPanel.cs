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
        [SerializeField] private GameObject _infoObject;
        public void Show(GameObject infoObject)
        {
            gameObject.SetActive(true);
            _infoObject = infoObject;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _infoObject = null;
        }
    }

}
