using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicList : MonoBehaviour
{
    [SerializeField] private Transform ParentTransform;
    [SerializeField] private DynamicButton ButtonTemplate;
    public void CreateButtons(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            Instantiate(ButtonTemplate, ParentTransform).Init(obj);
        }
    }
}
