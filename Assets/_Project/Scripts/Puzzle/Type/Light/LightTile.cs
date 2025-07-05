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
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite inactiveSprite;
        
        // Reference
        private LightPuzzle _lightPuzzle;
        
        // Initialize
        public void InitLightTile(LightPuzzle lightPuzzle, (int row, int col) matrix)
        {
            // Stats
            IsActive = false;
            
            tileRow = matrix.row;
            tileColumn = matrix.col;
            tileImageUI.sprite = inactiveSprite;
           
            _lightPuzzle = lightPuzzle;
            
            // Button
            tileButtonUI.onClick.AddListener(OnClickTile);
        }
        
        // Core
        public void ToggleTile()
        {
            IsActive = !IsActive;
            tileImageUI.sprite = IsActive ? activeSprite : inactiveSprite;
        }
        
        private void OnClickTile()
        {
            if (_lightPuzzle == null)
            {
                Debug.LogWarning("lightPuzzle is null!");
                return;
            }
            _lightPuzzle.HandleLights(tileRow, tileColumn);
        }
    }
}