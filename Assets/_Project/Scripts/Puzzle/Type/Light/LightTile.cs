using System;
using UnityEngine;
using UnityEngine.UI;
using KevinCastejon.MoreAttributes;

namespace Echoes.Puzzle
{
    public class LightTile : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] [ReadOnlyOnPlay] private int tileRow;
        [SerializeField] [ReadOnlyOnPlay] private int tileColumn;

        public bool IsActive { get; private set; }

        [Header("UI")]
        [SerializeField] private Image tileImageUI;
        [SerializeField] private Button tileButtonUI;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color inactiveColor;
        
        // Reference
        private LightPuzzle _lightPuzzle;
        
        // Initialize
        public void InitLightTile(LightPuzzle lightPuzzle, (int row, int col) matrix)
        {
            // Stats
            IsActive = false;
            
            tileRow = matrix.row;
            tileColumn = matrix.col;
            tileImageUI.color = inactiveColor;
           
            _lightPuzzle = lightPuzzle;
            
            // Button
            tileButtonUI.onClick.AddListener(() => _lightPuzzle.HandleLights(tileRow, tileColumn));
        }
        
        // Core
        public void ToggleTile()
        {
            IsActive = !IsActive;
            ChangeTileImage();
        }
        
        private void ChangeTileImage()
        {
            var colorTarget = IsActive ? activeColor : inactiveColor;
            tileImageUI.color = colorTarget;
        }
    }
}