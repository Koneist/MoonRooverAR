using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonRooverAR
{
    public class VehicleSelector : MonoBehaviour
    {
        [SerializeField] private VehicleMenuVisualizator _visualizator;
        [SerializeField] private GameObject _currentVehicle;
        [SerializeField] private int _showedVehicle = 0;
        [SerializeField] private int _selectedVehicle = 0;
        [SerializeField] private VehicleInfo[] _selectableVehicles;
        [SerializeField] private VehicleAttacher _attacher;

        public int SelectedVehicle
        {
            get => _selectedVehicle;
            set => _selectedVehicle = value;
        }

        public void ShowVehicle(int id)
        {
            _visualizator.Show(_selectableVehicles[id]);
            _showedVehicle = id;
        }

        public void SelectVehicle()
        {
            _selectedVehicle = _showedVehicle;
            ChangeVehicle(_selectedVehicle);
        }

        public void ChangeVehicle(int id)
        {
            _attacher.ChangeVehicle(_selectableVehicles[id].VehicleRef);
        }
    }

}
