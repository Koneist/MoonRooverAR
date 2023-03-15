using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; set; }
        public SaveState State;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
            }

            Load();
            
        }

        public void Save()
        {
            PlayerPrefs.SetString("save", Helper.Serialize(State));
        }

        public void Load()
        {
            if(!PlayerPrefs.HasKey("save"))
            {
                State = new SaveState();
                Save();
                Debug.Log("No save file found, creating a new one");
                return;
            }

            State = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
    }

}
