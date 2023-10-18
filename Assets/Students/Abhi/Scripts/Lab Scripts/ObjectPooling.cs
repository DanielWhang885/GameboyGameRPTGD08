using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public int InitialPoolSize = 20;
    public GameObject Prefab1, Prefab2;
    public float offsetX = 5, offsetZ = 5;

    private List<GameObject> GameObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        GameObjectPool = new List<GameObject>();
        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject obj = Random.value < 0.5 ? Instantiate(Prefab1, transform.position + new Vector3(Random.Range(-offsetX, offsetX), 0, Random.Range(-offsetZ, offsetZ)), Quaternion.identity): Instantiate(Prefab2, transform.position + new Vector3(Random.Range(-offsetX, offsetX), 0, Random.Range(-offsetZ, offsetZ)), Quaternion.identity);
            obj.SetActive(false);
            GameObjectPool.Add(obj);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(SpawnBear());
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(DespawnBear());
        }
    }

    private IEnumerator SpawnBear()
    {
        CreateGameObject();
        yield return new WaitForSeconds(1f);
    }
    
    private IEnumerator DespawnBear()
    {
        DestroyGameObject();
        yield return new WaitForSeconds(1f);
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

        GameObject newObject = Random.value < 0.5 ? Instantiate(Prefab1, transform.position + new Vector3(Random.Range(-offsetX, offsetX), 0, Random.Range(-offsetZ, offsetZ)), Quaternion.identity) : Instantiate(Prefab2, transform.position + new Vector3(Random.Range(-offsetX, offsetX), 0, Random.Range(-offsetZ, offsetZ)), Quaternion.identity);
        GameObjectPool.Add(newObject);
        return newObject;
    }

    public void DestroyGameObject()
    {
        foreach (GameObject obj in GameObjectPool)
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false);
                return;
            }
        }
    }
}
