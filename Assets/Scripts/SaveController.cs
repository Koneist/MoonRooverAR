
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class SaveController : MonoBehaviour
    {
        [SerializeField] private GameObject _vehicle;
        [SerializeField] private PositionTracker _tracker;
        [SerializeField] private VehicleAttacher _attacher;
        [SerializeField] private VehicleSelector _selector;
        [SerializeField] private MenuController _menuController;
        [SerializeField] private Collection _collection;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            Load();
        }

        public void Load()
        {
            var posArr = SaveManager.Instance.State.Position;
            var rotArr = SaveManager.Instance.State.Rotarion;
            var collection = SaveManager.Instance.State.CollectionLock;
            var vehicleId = SaveManager.Instance.State.VehicleId;
            var isFirstTime = SaveManager.Instance.State.FirstSave;

            var pos = new Vector3(posArr[0], posArr[1], posArr[2]);
            var rot = new Quaternion(rotArr[0], rotArr[1], rotArr[2], rotArr[3]);
            

            for (int i = 0; i < _collection.CollectionObjects.Length; ++i)
                _collection.CollectionObjects[i].Locked = collection[i];

            _selector.SelectedVehicle = vehicleId;
            _selector.ChangeVehicle(vehicleId);

            _tracker.ChangePosition(pos);

            _attacher.Vehicle.transform.localPosition = pos;
            _attacher.Vehicle.transform.rotation = rot;

            if (isFirstTime)
                _menuController.ShowSelectVehicleMenu(isFirstTime);
        }

        public void Save()
        {
            var vehicle = _attacher.Vehicle;
            var pos = vehicle.transform.localPosition;
            var rot = vehicle.transform.rotation;
            var posArr = new[] { pos.x, pos.y + 0.1f, pos.z };
            var rotArr = new[] { rot.x, rot.y, rot.z, rot.w };

            var collection = new List<bool>(_collection.CollectionObjects.Length);
            foreach (var item in _collection.CollectionObjects)
                collection.Add(item.Locked);

            SaveManager.Instance.State.Position = posArr;
            SaveManager.Instance.State.Rotarion = rotArr;
            SaveManager.Instance.State.VehicleId = _selector.SelectedVehicle;
            SaveManager.Instance.State.CollectionLock = collection.ToArray();

            SaveManager.Instance.Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (!pause)
                return;

            Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

    }

}
