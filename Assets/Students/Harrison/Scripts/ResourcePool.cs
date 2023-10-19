using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourcePool : MonoBehaviour, ISerializationCallbackReceiver
{
    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        TMPList = _resourceTypes;
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize(){}

    [SerializeField] private List<string> _resourceTypes;
    [SerializeField] public static List<string> TMPList = new List<string>();
    [ListToPopup(typeof(ResourcePool), "TMPList")]
    public string Popup;

    [ContextMenu("Update List")]
    public void UpdateList()
    {
        TMPList = _resourceTypes;
    }
    [SerializeField] private SerializableDictionary<string, int> _startingResources = new SerializableDictionary<string, int>();
    private int defaultResourceStart = 0;
    [SerializeField] private int _resourceCap;
    public Dictionary<string, int> numberOfResource { get; private set; } = new Dictionary<string, int>();

    private void Awake()
    {
        foreach (string resource in _startingResources.Keys)
        {
            Debug.Log($"{resource}");
            if (_startingResources.ContainsKey(resource))
            {
                numberOfResource.Add(resource, Mathf.Min(_startingResources[resource], _resourceCap));
            }
            else
            {
                numberOfResource.Add(resource, defaultResourceStart);
            }
        }

        foreach (string key in numberOfResource.Keys)
        {
            numberOfResource[key] = Mathf.Min(numberOfResource[key], _resourceCap);
        }
    }

    public bool TryRemoveResource(string resource, int ammount)
    {
        return (numberOfResource[resource] - ammount < 0);
    }

    public bool RemoveResource(string resource, int ammount)
    {
        if (numberOfResource[resource] - ammount < 0)
        {
            return false;
        }
        numberOfResource[resource] -= ammount;
        return true;
    }

    public void AddResource(string resource, int ammount)
    {
        numberOfResource[resource] = Mathf.Min(numberOfResource[resource] + ammount, _resourceCap);
    }
}
