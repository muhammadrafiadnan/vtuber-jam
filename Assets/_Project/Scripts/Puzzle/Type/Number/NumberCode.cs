using UnityEngine;
using TMPro;

namespace Echoes.Puzzle
{
    public class NumberCode : PuzzleBase
    {
        [Header("Attributes")]
        [SerializeField] private string correctCode;
        [SerializeField] private TextMeshProUGUI codeTextUI;

        private string _codeTextValue = "";

        // Initialize
        protected override void InitOnStart()
        {
            base.InitOnStart();
            codeTextUI.text = _codeTextValue;
        }
        
        // Core
        public void AddDigit(string digit)
        {
            if (_codeTextValue.Length < correctCode.Length)
            {
                _codeTextValue += digit;
                codeTextUI.text = _codeTextValue;
            }
        }
        
        public void ClearCode()
        {
            _codeTextValue = "";
            codeTextUI.text = _codeTextValue;
        }
        
        public void SubmitCode()
        {
            if (CheckPuzzleComplete())
            {
                Debug.Log("puzzle clear!");
                isPuzzleComplete = true;
                puzzleItem.ClearItem();
                ClosePuzzlePanel();
            }
            else
            {
                Debug.Log("wrong code bro!");
            }
        }
        
        protected override bool CheckPuzzleComplete()
        {
            return _codeTextValue == correctCode;
        }
    }
}
