using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeUI : MonoBehaviour
{
    [SerializeField] private DynamicList List;

    private void Start()
    {
        GameObject[] shapes = Resources.LoadAll<GameObject>("Shapes");
        List.CreateButtons(shapes);
    }
}
