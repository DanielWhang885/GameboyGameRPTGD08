using UnityEngine;

public class Enemy_Buildings : MonoBehaviour
{
    //Helper script for storing different assets and values related to enemy buildings
    public enum BUILDING_TYPE
    {
        TOWNHALL,
        HOUSE,
        FARM,
        BARRACKS,
        ARCHERY,
        STABLES,
        BLACKSMITH,
        WORKSHOP,
        TOWER,
        LUMBERMILL,
        MAGETOWER,
        TEMPLE,
        LIBRARY,
        MARKET,
        GRANARY,
    }

    public static Vector2Int getBuildingCost(BUILDING_TYPE BUILDING)
    {
        switch (BUILDING)
        {
            default:
            case BUILDING_TYPE.TOWNHALL: return new Vector2Int(1200,600);
            case BUILDING_TYPE.HOUSE: return new Vector2Int(450,50);
            case BUILDING_TYPE.FARM: return new Vector2Int(450,50);
        }
    }
    
    public static float getConstructionTime(BUILDING_TYPE BUILDING)
    {
        switch (BUILDING)
        {
            default:
            case BUILDING_TYPE.TOWNHALL: return 30f;
            case BUILDING_TYPE.HOUSE: return 15f;
            case BUILDING_TYPE.FARM: return 15f;
        }
    }
    
    public static GameObject getBuildingPrefab(BUILDING_TYPE BUILDING)
    {
        switch (BUILDING)
        {
            default:
            case BUILDING_TYPE.TOWNHALL: return Resources.Load<GameObject>("Buildings/TownHall");
            case BUILDING_TYPE.HOUSE: return Resources.Load<GameObject>("Buildings/House");
            case BUILDING_TYPE.FARM: return Resources.Load<GameObject>("Buildings/Farm");
        }
    }
}
