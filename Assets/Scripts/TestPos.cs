using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPos : MonoBehaviour
{
    [SerializeField] private Text _output;

    [SerializeField] private Transform _indicator;
    [SerializeField] private Transform _object;

    private void FixedUpdate()
    {
        _output.text = $"Indicator {_indicator.position} Object {_object.position}";
    }
}
