using UnityEngine;
using Echoes.Gameplay;
using Echoes.Managers;

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
        protected PuzzleManager puzzleManager;

        // Unity Callbacks
        private void Awake()
        {
            InitOnAwake();
        }

        private void Start()
        {
            InitOnStart();
        }

        private void Update()
        {
            ModifyOnUpdate();
        }

        // Initialize
        protected virtual void InitOnAwake()
        {
            _puzzleAnim = GetComponent<PuzzleAnimation>();
        }
        
        protected virtual void InitOnStart()
        {
            isPuzzleActive = false;
            isPuzzleComplete = false;
        }
        
        protected virtual void ModifyOnUpdate()
        {
            if (!GameManager.Instance.IsGameStart) return;
            
            if (Input.GetKeyDown(KeyCode.Escape) && isPuzzleActive)
            {
                ClosePuzzlePanel();
            }
        }
        
        public void InjectManager(PuzzleManager manager) => puzzleManager = manager;
        
        // Core
        protected abstract bool CheckPuzzleComplete();
        protected virtual void ResetPuzzle() { }
        
        public void OpenPuzzlePanel()
        {
            if (gameObject.activeSelf || !GameManager.Instance.IsGameStart) return;
            
            gameObject.SetActive(true);
            _puzzleAnim.AnimateInPuzzle(puzzleWindowUI, () => isPuzzleActive = true);
        }
        
        protected void ClosePuzzlePanel()
        {
            if (!gameObject.activeSelf) return;
            
            isPuzzleActive = false;
            _puzzleAnim.AnimateOutPuzzle(ResetPuzzle);
        }

    }
}