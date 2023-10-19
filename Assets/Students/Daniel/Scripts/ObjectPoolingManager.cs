using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public int InitialPoolSize = 20;
    public GameObject Prefab;

    private List<GameObject> GameObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        GameObjectPool = new List<GameObject>();
        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.SetActive(false);
            GameObjectPool.Add(obj);
        }
    }

    public GameObject CreateGameObject()
    {
        foreach (GameObject obj in GameObjectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObject = Instantiate(Prefab);
        GameObjectPool.Add(newObject);
        return newObject;
    }

    public void DestroyGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }


// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateGameObject();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Runs DestroyGameObject function from pool manager script
            foreach (GameObject obj in GameObjectPool)
            {
                DestroyGameObject(Prefab);
            }
        }
    }
}
