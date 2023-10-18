using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public int AmountToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < AmountToSpawn; i++)
            {
                Instantiate(PrefabToSpawn);
            }
        }
    }
}
