using UnityEngine;
using Echoes.Puzzle;

namespace Echoes.Gameplay
{
    public class ItemController : MonoBehaviour, IClickable
    {
        [Header("Stats")] 
        [SerializeField] private string itemName;
        [SerializeField] private PuzzleBase puzzleBase;
        
        public void Click() => puzzleBase.OpenPuzzlePanel();
        public void ClearItem() => gameObject.SetActive(false);
    }
}