using MoonRooverAR;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class VehicleInfo : MonoBehaviour
{
    [SerializeField] private Button _changeButton;
    [SerializeField] private ObjectVisualizator _visualizator;
    [SerializeField] private VehicleSelector _selector;
    [SerializeField] private Image _previewImage;
    
    [SerializeField] private Sprite _objectSprite;
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    [SerializeField] public GameObject VehicleRef;

    private Button _button;
    public Sprite ObjectSprite { get => _objectSprite; }
    public string Name { get => _name; }
    public string Description { get => _description; }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _previewImage.sprite = _objectSprite;
    }

    public void ShowObject()
    {
        _visualizator.Show(_name, _description, _objectSprite, false);
        _changeButton.onClick.RemoveAllListeners();
        _changeButton.onClick.AddListener(SelectVehicle);
    }

    public void SelectVehicle()
    {
        _selector.SelectVehicle(this);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowObject);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowObject);
    }
}
