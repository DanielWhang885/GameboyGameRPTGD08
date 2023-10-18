using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Bear Unit", fileName = "BearUnitData")]
public class BearUnitScriptableObject : ScriptableObject
{
    public float attackStat = 10.0f;
    public float speedStat = 5.0f;
    public float lifeSpan = 10.0f;
}
