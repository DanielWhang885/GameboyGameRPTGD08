using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystems
{
    public class PlacementSystem : MonoBehaviour
    {
        [SerializeField] private GameObject mouseIndicator;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Grid grid;

        [SerializeField] private BuildingsDatabaseSO database;
        [SerializeField] private int selectedObjetIndex = -1;

        [SerializeField] private GameObject gridVisualization;

        private GridData buildingData;

        private List<GameObject> placedGameObjects = new();

        [SerializeField] private PreviewSystem preview;

        private Vector3Int lastDetectedPosition = Vector3Int.zero;

        private void Start()
        {
            StopPlacement();

            buildingData = new();
        }

        public void StartPlacement(int ID)
        {
            StopPlacement();

            selectedObjetIndex = database.buildingsData.FindIndex(data => data.ID == ID);
            if (selectedObjetIndex < 0)
            {
                Debug.LogError($"No ID Found {ID}");
                return;
            }

            gridVisualization.SetActive(true);
            preview.StartShowingPlacementPreview(database.buildingsData[selectedObjetIndex].gameObject, database.buildingsData[selectedObjetIndex].Size);
            inputManager.OnClicked += PlaceStructure;
            inputManager.OnExit += StopPlacement;
        }

        private void PlaceStructure()
        {
            if (inputManager.IsPointerOverUI())
            {
                return;
            }
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);

            bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjetIndex);
            if (!placementValidity)
            {
                return;
            }

            GameObject newBuilding = Instantiate(database.buildingsData[selectedObjetIndex].gameObject);
            newBuilding.transform.position = gridPosition;

            placedGameObjects.Add(newBuilding);

            buildingData.AddObjectAt(gridPosition, database.buildingsData[selectedObjetIndex].Size, database.buildingsData[selectedObjetIndex].ID, placedGameObjects.Count - 1);
            preview.UpdatePosition(grid.CellToWorld(gridPosition), false);
        }

        private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjetIndex)
        {
            return buildingData.CanPlaceObjectAt(gridPosition, database.buildingsData[selectedObjetIndex].Size);
        }

        private void StopPlacement()
        {
            selectedObjetIndex = -1;
            gridVisualization.SetActive(false);
            preview.StopShowingPreview();
            inputManager.OnClicked -= PlaceStructure;
            inputManager.OnExit -= StopPlacement;
            lastDetectedPosition = Vector3Int.zero;
        }

        private void Update()
        {
            if (selectedObjetIndex < 0)
            {
                return;
            }

            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);

            if (lastDetectedPosition != gridPosition)
            {
                bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjetIndex);

                mouseIndicator.transform.position = mousePosition;
                preview.UpdatePosition(grid.CellToWorld(gridPosition), placementValidity);
                lastDetectedPosition = gridPosition;
            }
        }
    }
}
