using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystems 
{
    [CreateAssetMenu]
    public class BuildingsDatabaseSO : ScriptableObject
    {
        public List<Building> buildingsData;
    }
}
