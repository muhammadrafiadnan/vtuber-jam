using UnityEngine;
using Echoes.Puzzle;

namespace Echoes.Gameplay
{
    public class ItemController : MonoBehaviour
    {
        [Header("Stats")] 
        [SerializeField] private string itemName;
        [SerializeField] private PuzzleBase puzzleBase;
        
        public void ClickItem()
        {
            puzzleBase.OpenPuzzlePanel();
        }
        
        public void ClearItem()
        {
            gameObject.SetActive(false);
        }

    }
}