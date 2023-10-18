using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingSystems
{
    public class InputManager : MonoBehaviour
    {
        private Camera sceneCamera;
        [SerializeField] private LayerMask placementLayerMask;

        private Vector3 lastPosition;

        public event Action OnClicked, OnExit;

        private void Awake()
        {
            sceneCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnClicked?.Invoke();
            if (Input.GetKeyDown(KeyCode.Escape))
                OnExit?.Invoke();
        }

        public bool IsPointerOverUI()
            => EventSystem.current.IsPointerOverGameObject();

        public Vector3 GetSelectedMapPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = sceneCamera.nearClipPlane;
            Ray ray = sceneCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
            {
                lastPosition = hit.point;
            }

            return lastPosition;
        }
    }
}
