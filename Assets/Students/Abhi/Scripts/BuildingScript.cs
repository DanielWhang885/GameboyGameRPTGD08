using UnityEngine;

public abstract class BuildingScript : MonoBehaviour
{
    [SerializeField] private GameObject buildingUI;

    private void Awake()
    {
        if (buildingUI == null)
        {
            buildingUI = GameObject.Find("building_UI");
        }
    }

    private void OnMouseUp()
    {
        buildingUI.SetActive(true);
    }
}
