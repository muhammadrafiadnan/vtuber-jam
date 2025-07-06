using UnityEngine;
using UnityEngine.UI;

namespace Echoes.Puzzle
{
    public class LightPuzzle : PuzzleBase
    {
        [Header("Attributes")] 
        [SerializeField] [Range(0, 5)] private int rowNum;
        [SerializeField] [Range(0, 5)] private int columnNum;
        [SerializeField] private LightTile[] lightTiles;
        [SerializeField] private Button clearButton;
        
        private LightTile[,] _lightTiles;
        
        // Initialize
        protected override void InitOnStart()
        {
            base.InitOnStart();
            if (!ValidateLight())
            {
                Debug.Log("invalid tile lights!");
                return;
            }
            
            // Init 2D array
            var tileIndex = 0;
            _lightTiles = new LightTile[rowNum, columnNum];
            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 0; j < columnNum; j++)
                {
                    _lightTiles[i, j] = lightTiles[tileIndex];
                    _lightTiles[i, j].InitLightTile(this, (i, j));
                    tileIndex++;
                }
            }
            
            // Init button
            clearButton.onClick.AddListener(ResetPuzzle);
        }
        
        // Core
        public void HandleLights(int row, int column)
        {
            if (!isPuzzleActive || isPuzzleComplete) return;
            
            var selectedTile = _lightTiles[row, column];
            if (selectedTile == null)
            {
                Debug.LogWarning($"selectedTile row: {row}, column: {column} is null!");
                return;
            }
            
            selectedTile.ToggleTile();
            
            // Modify tile around
            if (column > 0) _lightTiles[row, column - 1].ToggleTile();
            if (column + 1 < columnNum) _lightTiles[row, column + 1].ToggleTile();
            if (row > 0) _lightTiles[row - 1, column].ToggleTile();
            if (row + 1 < rowNum) _lightTiles[row  + 1, column].ToggleTile();
            
            // Checkup puzzle
            if (CheckPuzzleComplete())
            {
                isPuzzleComplete = true;
                puzzleItem.ClearItem();
                ClosePuzzlePanel();
            }

            CheckPuzzleComplete();
        }
        
        protected override bool CheckPuzzleComplete()
        {
            var lightActiveCount = 0;
            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 0; j < columnNum; j++)
                {
                    if (_lightTiles[i, j].IsActive)
                        lightActiveCount++;
                }
            }
            
            return lightActiveCount >= lightTiles.Length;
        }


        protected override void ResetPuzzle()
        {
            base.ResetPuzzle();
            for (var i = 0; i < rowNum; i++)
            {
                for (var j = 0; j < columnNum; j++)
                {
                    _lightTiles[i, j].ResetTile();
                }
            }
        }

        // Helpers
        private bool ValidateLight()
        {
            if (rowNum <= 1 && columnNum <= 1) return false;
            if (rowNum % 2 == 0 && columnNum % 2 == 0) return false;
            if (lightTiles.Length / rowNum != rowNum) return false;
            
            return columnNum == rowNum;
        }
    }
}
