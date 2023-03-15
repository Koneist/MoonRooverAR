
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace MoonRooverAR
{
    public class SaveController : MonoBehaviour
    {
        [SerializeField] private GameObject _vehicle;
        [SerializeField] private PositionTracker _tracker;
        [SerializeField] private VehicleAttacher _attacher;
        [SerializeField] private VehicleSelector _selector;
        [SerializeField] private Collection _colletion;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            Load();
        }

        public void Load()
        {
            var posArr = SaveManager.Instance.State.Position;
            var rotArr = SaveManager.Instance.State.Rotarion;
            var collection = SaveManager.Instance.State.CollectionUnlock;
            var vehicleId = SaveManager.Instance.State.VehicleId;

            var pos = new Vector3(posArr[0], posArr[1], posArr[2]);
            var rot = new Quaternion(rotArr[0], rotArr[1], rotArr[2], rotArr[3]);

            for (int i = 0; i < collection.Length; ++i)
                _colletion.CollectionObjects[i].Locked = collection[i];

            _selector.SelectedVehicle = vehicleId;
            _selector.ChangeVehicle(vehicleId);

            _tracker.ChangePosition(pos);

            _attacher.Vehicle.transform.localPosition = pos;
            _attacher.Vehicle.transform.rotation = rot;
        }

        public void Save()
        {
            var vehicle = _attacher.Vehicle;
            var pos = vehicle.transform.localPosition;
            var rot = vehicle.transform.rotation;
            var posArr = new[] { pos.x, pos.y + 0.1f, pos.z };
            var rotArr = new[] { rot.x, rot.y, rot.z, rot.w };

            var collection = new List<bool>(_colletion.CollectionObjects.Length);
            foreach (var item in _colletion.CollectionObjects)
                collection.Add(item.Locked);

            SaveManager.Instance.State.Position = posArr;
            SaveManager.Instance.State.Rotarion = rotArr;
            SaveManager.Instance.State.VehicleId = _selector.SelectedVehicle;
            SaveManager.Instance.State.CollectionUnlock = collection.ToArray();

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
