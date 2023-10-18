using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<UnitScript> playerUnits = new List<UnitScript>();
    public List<BuildingScript> playerBuildings = new List<BuildingScript>();

    public static GameManager instance;

    private void Awake()
    {
        //Singleton logic
        if(instance)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        //Checking for player's buildings and units to keep track of them.
        foreach (BuildingScript building in FindObjectsOfType<BuildingScript>())
        {
            if (building.CompareTag("Player"))
            {
                playerBuildings.Add(building);
            }
        }

        foreach (UnitScript unit in FindObjectsOfType<UnitScript>())
        {
            if (unit.CompareTag("Player"))
            {
                playerUnits.Add(unit);
            }
        }
    }

    private void Update()
    {
        //Player loses once all of their units and buildings are wiped out.
        if (playerBuildings.Count <= 0 && playerUnits.Count <= 0)
        {
            Defeat();
        }
    }

    public void Victory()
    {
        //TODO: Load Win screen
    }

    public void Defeat()
    {
        //TODO: Load Lose screen
    }
}
