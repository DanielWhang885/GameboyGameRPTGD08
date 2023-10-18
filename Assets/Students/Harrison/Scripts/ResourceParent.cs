using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceParent : MonoBehaviour
{
    [SerializeField] protected int startingResourceAmmount = 200;
    public string resourceType { get; protected set; }
    public int resourceLeft { get; protected set; } = 0;

    protected void Start()
    {
        resourceLeft = startingResourceAmmount;
    }

    public bool TryGetResources(int ammountToTake, out int ammountTaken) 
    {
        if (ammountToTake > resourceLeft)
        {
            ammountTaken = 0;
            return false;
        }
        resourceLeft -= ammountToTake;
        ammountTaken = ammountToTake;
        return true;
    }
    public bool TryGetResources(int ammountToTake)
    {
        if (ammountToTake > resourceLeft)
        {
            return false;
        }
        return true;
    }
    public int GetResources(int ammountToTake)
    {
        if (ammountToTake > resourceLeft)
        {
            Debug.LogError("Trying to take more resources than resource has.");
            return 0;
        }
        resourceLeft -= ammountToTake;
        return ammountToTake;
    }
}
