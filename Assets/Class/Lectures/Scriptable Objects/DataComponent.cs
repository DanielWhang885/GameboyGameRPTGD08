using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataComponent : MonoBehaviour
{
    public DataScriptableObject Data;

    void Start()
    {
        int i = 0;
        Debug.Log($"{Data.GetDataAt(i)}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
