using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_AI_Manager : MonoBehaviour
{
    public List<UnitScript> enemyUnits = new List<UnitScript>();
    public List<BuildingScript> enemyBuildings = new List<BuildingScript>();
    public Dictionary<string, bool> priorities = new Dictionary<string, bool>();
    public Vector2Int resources, foodAndHousing;    

    public static NPC_AI_Manager instance;
    public int enemyStartFood = 5, enemyStartWood = 1000, enemyStartGold = 1000, enemyStartHousing = 5;

    public enum PRIORITIES
    {
        SAFETY,
        GOLD,
        WOOD,
        TOWNHALL,
        FOOD,
        HOUSING,
        REPAIR,
    }

    private void Awake()
    {
        //Singleton
        if (instance)
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
        //Initialize enemy resources
        resources = new Vector2Int(enemyStartGold, enemyStartWood);
        foodAndHousing = new Vector2Int(enemyStartFood, enemyStartHousing);

        //Checking for enemy's buildings and units to keep track of them.
        foreach (BuildingScript building in FindObjectsOfType<BuildingScript>())
        {
            if(building.CompareTag("Enemy"))
            {
                enemyBuildings.Add(building);
            }
        }
        
        foreach(UnitScript unit in FindObjectsOfType<UnitScript>())
        {
            if(unit.CompareTag("Enemy"))
            {
                enemyUnits.Add(unit);
            }
        }
    }

    private void Update()
    {
        //Player wins once they wipe out all enemy units and buildings
        if(enemyBuildings.Count <= 0 && enemyUnits.Count <= 0)
        {
            GameManager.instance.Victory();
        }

        //Testing spawning functionality
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Enemy_Units.getUnitPrefab(Enemy_Units.UNIT_TYPE.PEASANT), transform.position, Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            //var temp = Instantiate(Enemy_Buildings.getBuildingPrefab(Enemy_Buildings.BUILDING_TYPE.TOWNHALL), transform.position, Quaternion.identity);
            //temp.transform.Rotate(270, 0, 0);
        }
    }

    private void TrainPeasant()
    {
        Enemy_TownHall townHall = GetTownHall();
        if(townHall != null)
        {
            townHall.TrainPeasant();
        }
    }

    private Enemy_TownHall GetTownHall()
    {
        foreach(BuildingScript buildingScript in enemyBuildings)
        {
            if(buildingScript.GetComponent<Enemy_TownHall>())
            {
                return buildingScript.GetComponent<Enemy_TownHall>();
            }
        }
        return null;
    }
    
    private Enemy_Peasant GetPeasant()
    {
        foreach(UnitScript unitScript in enemyUnits)
        {
            if(unitScript.GetComponent<Enemy_Peasant>())
            {
                return unitScript.GetComponent<Enemy_Peasant>();
            }
        }
        return null;
    }
}
