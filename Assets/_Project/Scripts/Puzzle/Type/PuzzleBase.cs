using UnityEngine;

namespace Echoes.Puzzle
{
    public class PuzzleBase : MonoBehaviour
    {
        [Header("Base")] 
        [SerializeField] protected GameObject puzzlePanelUI;
        
        protected bool isPuzzleComplete;
        public bool IsPuzzleComplete => isPuzzleComplete;
        
        private void Start()
        {
            InitPuzzleStats();
        }

        protected virtual void InitPuzzleStats() { }
        protected virtual bool CheckPuzzleComplete() { return false; }

        public void OpenPuzzlePanel()
        {
            
        }

        public void ClosePuzzlePanel()
        {
            
        }

    }
}