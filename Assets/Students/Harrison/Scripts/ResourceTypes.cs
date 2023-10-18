using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTypes : MonoBehaviour
{
    public List<string> _resource;
    public static GameObject instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this.gameObject;
        DontDestroyOnLoad(this);
    }
}
