using Echoes.Gameplay;
using UnityEngine;

namespace Echoes.Puzzle
{
    public abstract class PuzzleBase : MonoBehaviour
    {
        [Header("Base")] 
        [SerializeField] private GameObject puzzleWindowUI;
        [SerializeField] protected ItemController puzzleItem;

        protected bool isPuzzleActive;
        protected bool isPuzzleComplete;
        
        public bool IsPuzzleComplete => isPuzzleComplete;

        // Reference
        private PuzzleAnimation _puzzleAnim;

        // Unity Callbacks
        private void Awake()
        {
            _puzzleAnim = GetComponent<PuzzleAnimation>();
        }

        private void Start()
        {
            InitPuzzleStats();
        }

        private void Update()
        {
            ModifyOnUpdate();
        }

        // Initialize
        
        protected virtual void InitPuzzleStats()
        {
            isPuzzleActive = false;
            isPuzzleComplete = false;
        }
        
        protected virtual void ModifyOnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePuzzlePanel();
            }
        }
        
        // Core
        protected abstract void CheckPuzzleComplete();
        protected virtual void ResetPuzzle() { }
        
        public void OpenPuzzlePanel()
        {
            isPuzzleActive = false;
            gameObject.SetActive(true);
            _puzzleAnim.AnimateInPuzzle(puzzleWindowUI, () => isPuzzleActive = true);
        }

        protected void ClosePuzzlePanel()
        {
            isPuzzleActive = false;
            _puzzleAnim.AnimateOutPuzzle(ResetPuzzle);
        }

    }
}