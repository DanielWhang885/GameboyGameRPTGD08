using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/BearData", fileName = "Test")]
public class BearScriptableObject : ScriptableObject
{
    public float attack = 100f;
    public float health = 50;

    public float GetAttack()
    {
        return attack;
    }
    
    public float GetHealth()
    {
        return health;
    }
}
