using System;
using UnityEngine;

namespace Echoes.Gameplay
{
    public class CursorController : MonoBehaviour
    {
        private Ray _rayCursor;
        private Camera _mainCamera;

        // Unity Callbacks
        private void Start()
        {
            _mainCamera = Camera.main;
        }
            
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickObject();
            }
        }
        
        // Core
        private void ClickObject()
        {
            _rayCursor = _mainCamera.ScreenPointToRay(Input.mousePosition);
                
            // Alloc intersection
            RaycastHit2D[] hit2DNonAlloc = new RaycastHit2D[1];
            var numOfHits = Physics2D.GetRayIntersectionNonAlloc(_rayCursor, hit2DNonAlloc);
            foreach (var rayHit in hit2DNonAlloc)
            {
                if (rayHit.collider == null) return;
                if (rayHit.collider.CompareTag("Item"))
                {
                    var rayHitInterface = rayHit.collider.GetComponent<ItemController>();
                    rayHitInterface.ClickItem();
                }
            }
        }
    }
}