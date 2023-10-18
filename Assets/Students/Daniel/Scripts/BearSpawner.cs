using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawner : MonoBehaviour
{
    public ObjectPoolingManager ObjectPool;
    public GameObject PrefabToSpawn;
    public int AmountToSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < AmountToSpawn; i++)
            {
                ObjectPool.CreateGameObject();
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //I'd put DestroyGameObject here, but I don't know how ot specify an object to destroy
        }
    }
}
