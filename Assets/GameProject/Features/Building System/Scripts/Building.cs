using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystems
{
    public class Building : MonoBehaviour
    {
        [field: SerializeField] public string BuildingName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public Vector2Int Size { get; private set; } = Vector2Int.one;
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; } = 100;


        protected int health;

    }
}
