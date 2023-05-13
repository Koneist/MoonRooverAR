using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    [System.Serializable]
    public class SaveState
    {
        public float[] Position = { 0f, 0.1f, 0f };
        public float[] Rotarion = { 0f, 0f, 0f, 0f };
        public bool[] CollectionLock = {true, true, true, true, true, true };
        public int VehicleId = 0;
        public bool FirstSave = true;
    }

}
