using UnityEngine;
using UnityEngine.UI;

namespace Echoes.Puzzle
{
    public class ImagePuzzle : MonoBehaviour
    {
        public Sprite[] tileSprites;
        public GameObject tilePrefab;
        public RectTransform puzzleContainer;
        public float tileSize;

        private GameObject[,] tiles = new GameObject[4, 4];
        private Vector2Int emptyTilePos = new Vector2Int(3, 3);

        void Start()
        {
            InitPuzzle();
            ShuffleTiles();
        }

        void InitPuzzle()
        {
            int spriteIndex = 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (x == 3 && y == 3)
                        continue;

                    GameObject tile = Instantiate(tilePrefab, puzzleContainer);
                    tile.GetComponent<Image>().sprite = tileSprites[spriteIndex];

                    GameObject currentTile = tile;
                    currentTile.GetComponent<Button>().onClick.AddListener(() => TryMove(currentTile));

                    RectTransform rect = tile.GetComponent<RectTransform>();
                    rect.anchoredPosition = GetTilePositionFromGrid(new Vector2Int(x, y));

                    tiles[x, y] = tile;
                    spriteIndex++;
                }
            }
        }

        void TryMove(GameObject tile)
        {
            Vector2Int tilePos = GetTilePosition(tile);

            if (IsAdjacent(tilePos, emptyTilePos))
            {
                RectTransform tileRect = tile.GetComponent<RectTransform>();
                tileRect.anchoredPosition = GetTilePositionFromGrid(emptyTilePos);

                tiles[emptyTilePos.x, emptyTilePos.y] = tile;
                tiles[tilePos.x, tilePos.y] = null;

                emptyTilePos = tilePos;
            }
            CheckWin();
        }

        Vector2Int GetTilePosition(GameObject tile)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (tiles[x, y] == tile)
                        return new Vector2Int(x, y);
                }
            }

            return new Vector2Int(-1, -1);
        }

        Vector2 GetTilePositionFromGrid(Vector2Int gridPos)
        {
            return new Vector2(gridPos.x * tileSize, -gridPos.y * tileSize);
        }

        bool IsAdjacent(Vector2Int a, Vector2Int b)
        {
            int dx = Mathf.Abs(a.x - b.x);
            int dy = Mathf.Abs(a.y - b.y);
            return dx + dy == 1;
        }
        void ShuffleTiles()
        {
            System.Collections.Generic.List<Vector2Int> positions = new();

            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    if (!(x == emptyTilePos.x && y == emptyTilePos.y))
                        positions.Add(new Vector2Int(x, y));

            for (int i = positions.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (positions[i], positions[j]) = (positions[j], positions[i]);
            }

            GameObject[] tempTiles = new GameObject[15];
            int index = 0;
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    if (!(x == emptyTilePos.x && y == emptyTilePos.y))
                        tempTiles[index++] = tiles[x, y];

            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    tiles[x, y] = null;

            for (int i = 0; i < tempTiles.Length; i++)
            {
                Vector2Int pos = positions[i];
                tiles[pos.x, pos.y] = tempTiles[i];
                RectTransform rect = tempTiles[i].GetComponent<RectTransform>();
                rect.anchoredPosition = GetTilePositionFromGrid(pos);
            }
        }
        void CheckWin()
        {
            int expectedIndex = 0;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (x == 3 && y == 3)
                    {
                        if (tiles[x, y] != null)
                            return;
                        continue;
                    }

                    GameObject tile = tiles[x, y];
                    if (tile == null)
                        return;

                    Image img = tile.GetComponent<Image>();
                    if (img.sprite != tileSprites[expectedIndex])
                        return;

                    expectedIndex++;
                }
            }
            Debug.Log("Clear!");
        }
    }
}
