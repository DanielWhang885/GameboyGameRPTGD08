using UnityEditor;
using UnityEngine;

public static class Enemy_Units
{
    //Helper script for storing different assets and values related to enemy units
    public enum UNIT_TYPE
    {
        PEASANT,
        FOOTMAN,
        ARCHER,
        KNIGHT,
        MAGE,
        BALLISTA,
    }

    public static Vector2Int getUnitCost(UNIT_TYPE unit)
    {
        switch(unit)
        {
            default:
            case UNIT_TYPE.PEASANT: return new Vector2Int(400, 0);
            case UNIT_TYPE.FOOTMAN: return new Vector2Int(600, 0);
            case UNIT_TYPE.ARCHER: return new Vector2Int(500, 150);
            case UNIT_TYPE.KNIGHT: return new Vector2Int(900, 450);
            case UNIT_TYPE.BALLISTA: return new Vector2Int(1000, 500);
            case UNIT_TYPE.MAGE: return new Vector2Int(1200, 0);
        }
    }
    
    public static Vector2Int getFoodAndHousing(UNIT_TYPE unit)
    {
        switch(unit)
        {
            default:
            case UNIT_TYPE.PEASANT: return new Vector2Int(1, 1);
            case UNIT_TYPE.FOOTMAN: return new Vector2Int(2, 1);
            case UNIT_TYPE.ARCHER: return new Vector2Int(2, 1);
            case UNIT_TYPE.KNIGHT: return new Vector2Int(3, 2);
            case UNIT_TYPE.BALLISTA: return new Vector2Int(2, 3);
            case UNIT_TYPE.MAGE: return new Vector2Int(2, 2);
        }
    }
    
    public static float getUnitTrainingTime(UNIT_TYPE unit)
    {
        switch(unit)
        {
            default:
            case UNIT_TYPE.PEASANT: return 5f;
            case UNIT_TYPE.FOOTMAN: return 6f; 
            case UNIT_TYPE.ARCHER: return 7f; 
            case UNIT_TYPE.KNIGHT: return 10f; 
            case UNIT_TYPE.BALLISTA: return 15f;
            case UNIT_TYPE.MAGE: return 13f; 
        }
    }
    
    public static GameObject getUnitPrefab(UNIT_TYPE unit)
    {
        switch(unit)
        {
            default:
            case UNIT_TYPE.PEASANT: return Resources.Load<GameObject>("Units/Peasant");
            case UNIT_TYPE.FOOTMAN: return Resources.Load<GameObject>("Units/Footman"); 
            case UNIT_TYPE.ARCHER: return Resources.Load<GameObject>("Units/Archer"); 
            case UNIT_TYPE.KNIGHT: return Resources.Load<GameObject>("Units/Knight"); 
            case UNIT_TYPE.BALLISTA: return Resources.Load<GameObject>("Units/Ballista");
            case UNIT_TYPE.MAGE: return Resources.Load<GameObject>("Units/Mage"); 
        }
    }
}
