using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUnitPoolScript : MonoBehaviour
{
    [SerializeField] private int _initialPoolSize = 10;
    [SerializeField] private GameObject _prefab;
    public static BearUnitPoolScript instance;

    private Queue<GameObject> _objectPool = new Queue<GameObject>();

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            GameObject obj = Instantiate(_prefab);
            obj.SetActive(false);
            _objectPool.Enqueue(obj);
        }
    }

    public GameObject SpawnGameObject()
    {
        GameObject obj;
        if (_objectPool.Count > 0)
        {
            obj = _objectPool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = GameObject.Instantiate(_prefab);
        }
        return obj;
    }

    public void DespawnGameObject(GameObject obj)
    {
        obj.SetActive(false);
        _objectPool.Enqueue(obj);
    }
}
