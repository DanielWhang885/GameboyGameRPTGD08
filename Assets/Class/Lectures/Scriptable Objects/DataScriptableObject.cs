using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Data Example", fileName = "Example")]
public class DataScriptableObject : ScriptableObject
{
    public int AmountOfParameters = 100;
    private List<float> Data = new List<float>();

    public float GetDataAt(int index)
    {
        return Data[index];
    }

    private void Awake()
    {
        for (int i = 0; i < AmountOfParameters; i++)
        {
            Data.Add(0.0f);
        }
    }
}
