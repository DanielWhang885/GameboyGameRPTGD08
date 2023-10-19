using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public BearScriptableObject bearData;

    private void OnEnable()
    {
        Debug.Log($"{bearData.GetAttack()}");
    }
    
    private void OnDisable()
    {
        Debug.Log($"{bearData.GetHealth()}");
    }
}
