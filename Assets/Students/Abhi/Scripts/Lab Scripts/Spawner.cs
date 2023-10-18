using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public int AmountToSpawn, AmountToDespawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < AmountToSpawn; i++)
            {
                //activate obj
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < AmountToSpawn; i++)
            {
                //deactivate obj
            }
        }
    }
}
