using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRooverAR
{
    public class SaveState
    {
        public float[] Position = { 0f, 0.1f, 0f };
        public float[] Rotarion = { 0f, 0f, 0f, 0f };
        public bool[] CollectionUnlock = {false, false, false, false, false, false};
        public int VehicleId = 0;
    }

}
