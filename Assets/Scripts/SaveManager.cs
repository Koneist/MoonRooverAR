using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MoonRooverAR
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; set; }
        public SaveState State;
        private string _saveDataFileName = "save.json";

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
            //PlayerPrefs.SetString("save", Helper.Serialize(State));
            var dataAsJson = JsonUtility.ToJson(State);
            var filePath = Path.Combine(Application.persistentDataPath, _saveDataFileName);
            File.WriteAllText(filePath, dataAsJson);
        }

        public void Load()
        {
            //if(!PlayerPrefs.HasKey("save"))
            //{
            //    State = new SaveState();
            //    Save();
            //    Debug.Log("No save file found, creating a new one");
            //    return;
            //}

            //State = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));

            var filePath = Path.Combine(Application.persistentDataPath, _saveDataFileName);
            
            if(!File.Exists(filePath))
            {
                State = new SaveState();
                Save();
                Debug.Log("No save file found, creating a new one");
                return;
            }

            var dataAsJson = File.ReadAllText(filePath);
            var data = JsonUtility.FromJson<SaveState>(dataAsJson);
            State = data;
        }

        public void ClearData()
        {
            State = new SaveState();

            Save();
        }
    }

}
