using System.Collections;
using UnityEngine;

public class Enemy_Peasant : MonoBehaviour
{
    private void Start()
    {
        //Check through priorities and start working on a task

        /*
         * Pseudocode
         * 
         * for(int i = 0; i < NPC_AI_Manager.instance.priorities.Count; i++)
         * {
         *      if(priorities[i] == true)
         *      {
         *      return;
         *      }
         *      else
         *      {
         *      StartCoroutine(StartTask[i])
         *      }         
         * }
         */
    }

    private IEnumerator StartTask(Coroutine TaskToDo)
    {
        //TODO:
        yield return null;
    }
}
