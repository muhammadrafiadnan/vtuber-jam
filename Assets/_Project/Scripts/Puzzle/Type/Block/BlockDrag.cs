using UnityEngine;
using UnityEngine.EventSystems;

namespace Echoes.Puzzle
{
    public class BlockDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Vector2Int sizeInGrid;
        public Vector2Int startGridPos;

        public float cellSize = 200;
        public float spacing = 10;

        private RectTransform rt;
        private Vector2 startPos;
        private Vector2Int currentGridPos;

        public bool isMainBlock = false;

        void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        void Start()
        {
            rt.anchorMin = rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.sizeDelta = new Vector2(
                sizeInGrid.x * cellSize + (sizeInGrid.x - 1) * spacing,
                sizeInGrid.y * cellSize + (sizeInGrid.y - 1) * spacing
            );
            rt.anchoredPosition = new Vector2(
                startGridPos.x * (cellSize + spacing),
                -startGridPos.y * (cellSize + spacing)
            );

            currentGridPos = startGridPos;
            BlockManager.Instance.SetOccupancy(currentGridPos, sizeInGrid, true);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPos = rt.anchoredPosition;
            BlockManager.Instance.SetOccupancy(currentGridPos, sizeInGrid, false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rt.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector2 snapPos = SnapToGrid(rt.anchoredPosition);
            Vector2Int targetGridPos = GetGridPosition(snapPos);

            Vector2Int delta = targetGridPos - currentGridPos;

            if ((delta.x != 0 && delta.y != 0) || delta == Vector2Int.zero)
            {
                ResetPosition();
                return;
            }

            BlockManager.Instance.SetOccupancy(currentGridPos, sizeInGrid, false);

            if (IsPathClear(currentGridPos, targetGridPos) &&
                BlockManager.Instance.IsSpaceAvailable(targetGridPos, sizeInGrid))
            {
                rt.anchoredPosition = new Vector2(
                    targetGridPos.x * (cellSize + spacing),
                    -targetGridPos.y * (cellSize + spacing)
                );
                currentGridPos = targetGridPos;
                BlockManager.Instance.SetOccupancy(currentGridPos, sizeInGrid, true);

                if (isMainBlock && currentGridPos == new Vector2Int(1, 3))
                {
                    Debug.Log("Clear!");
                }
            }
            else
            {
                ResetPosition();
            }
        }
        bool IsPathClear(Vector2Int from, Vector2Int to)
        {
            Vector2Int delta = to - from;
            Vector2Int direction = new Vector2Int(
                delta.x != 0 ? (delta.x > 0 ? 1 : -1) : 0,
                delta.y != 0 ? (delta.y > 0 ? 1 : -1) : 0
            );

            Vector2Int check = from + direction;

            while (check != to)
            {
                if (!BlockManager.Instance.IsSpaceAvailable(check, sizeInGrid))
                    return false;

                check += direction;
            }

            return true;
        }


        void ResetPosition()
        {
            rt.anchoredPosition = new Vector2(
                currentGridPos.x * (cellSize + spacing),
                -currentGridPos.y * (cellSize + spacing)
            );
            BlockManager.Instance.SetOccupancy(currentGridPos, sizeInGrid, true);
        }

        Vector2 SnapToGrid(Vector2 rawPos)
        {
            float total = cellSize + spacing;
            float x = Mathf.Round(rawPos.x / total) * total;
            float y = Mathf.Round(rawPos.y / total) * total;
            return new Vector2(x, y);   
        }

        Vector2Int GetGridPosition(Vector2 anchoredPos)
        {
            float total = cellSize + spacing;
            int x = Mathf.RoundToInt(anchoredPos.x / total);
            int y = Mathf.RoundToInt(-anchoredPos.y / total);
            return new Vector2Int(x, y);
        }

    }
}