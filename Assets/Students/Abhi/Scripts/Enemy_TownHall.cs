using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TownHall : BuildingScript
{
    private Vector2Int resourcesNeeded, currentResources;
    public void TrainPeasant()
    {
        //Check if there are enough resources to train a peasant
        currentResources = NPC_AI_Manager.instance.resources;
        resourcesNeeded = Enemy_Units.getUnitCost(Enemy_Units.UNIT_TYPE.PEASANT);

        if (currentResources.x > resourcesNeeded.x && currentResources.y > resourcesNeeded.y)
        {
            resourcesNeeded = Enemy_Units.getFoodAndHousing(Enemy_Units.UNIT_TYPE.PEASANT);
            if(currentResources.x > resourcesNeeded.x && currentResources.y > resourcesNeeded.y)
            {
                //Instantiate(Enemy_Units.UNIT_TYPE.PEASANT);
            }
        }
    }
}
