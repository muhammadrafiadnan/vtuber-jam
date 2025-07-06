using UnityEngine;
using UnityEngine.UI;

namespace Echoes.Puzzle
{
    public class BlockManager : PuzzleBase
    {
        public static BlockManager Instance;

        [Header("Grid Settings")]
        public int rows = 5;
        public int cols = 4;
        public float cellSize = 200;
        public float spacing = 10;

        [Header("References")]
        public RectTransform gridParent;
        public GameObject block1x1, block1x2, block2x1, block2x2;

        public bool[,] gridOccupied;

        protected override void InitOnAwake()
        {
            base.InitOnAwake();
            Instance = this;
        }

        protected override void InitOnStart()
        {
            base.InitOnStart();
            gridOccupied = new bool[rows, cols];
        }

        public void ClearPuzzle()
        {
            isPuzzleComplete = true;
            puzzleManager.CompletePuzzle();
            puzzleItem.ClearItem();
            ClosePuzzlePanel();
        }
        
        protected override bool CheckPuzzleComplete()
        {
            return true;
        }

        void SpawnBlock(GameObject prefab, Vector2Int gridPos, Vector2Int size)
        {
            GameObject block = Instantiate(prefab, gridParent);
            RectTransform rt = block.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            rt.sizeDelta = new Vector2(
                size.x * cellSize + (size.x - 1) * spacing,
                size.y * cellSize + (size.y - 1) * spacing
            );
            rt.anchoredPosition = new Vector2(
                gridPos.x * (cellSize + spacing),
                -gridPos.y * (cellSize + spacing)
            );

            BlockDrag drag = block.AddComponent<BlockDrag>();
            drag.sizeInGrid = size;
            drag.cellSize = cellSize;
            drag.spacing = spacing;
        }

        public bool IsSpaceAvailable(Vector2Int pos, Vector2Int size)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    int gx = pos.x + x;
                    int gy = pos.y + y;

                    if (gx < 0 || gx >= cols || gy < 0 || gy >= rows)
                        return false;

                    if (gridOccupied[gy, gx])
                        return false;
                }
            }
            return true;
        }

        public void SetOccupancy(Vector2Int pos, Vector2Int size, bool occupied)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    gridOccupied[pos.y + y, pos.x + x] = occupied;
                }
            }
        }
    }
}
