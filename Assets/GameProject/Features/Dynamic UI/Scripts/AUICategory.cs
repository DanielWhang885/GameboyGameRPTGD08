using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUICategory : MonoBehaviour
{
    public string ResourceFolder;
    [SerializeField] private DynamicGameList List;

    private void Start()
    {
        GameObject[] shapes = Resources.LoadAll<GameObject>(ResourceFolder);
        List.CreateButtons(shapes);
    }

    public virtual void OnButtonPressed(DynamicGameButton button)
    {
        //Functionality when this button is pressed
    }
}
