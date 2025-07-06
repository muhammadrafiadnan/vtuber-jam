using TMPro;
using UnityEngine;

namespace Echoes.Puzzle
{
    public class MorsePuzzle : PuzzleBase
    {
        [Header("Attributes")]
        [SerializeField] private TextMeshProUGUI inputDisplayText;
        [SerializeField] private string targetCode = "OPEN";
        [SerializeField] private int maxInputLength;

        private string _currentInput = "";

        // Methods
        protected override void ModifyOnUpdate()
        {
            base.ModifyOnUpdate();
            foreach (var key in Input.inputString)
            {
                if (char.IsLetterOrDigit(key) && _currentInput.Length < maxInputLength)
                {
                    _currentInput += char.ToUpper(key);
                }
                else if (key == '\b' && _currentInput.Length > 0)
                {
                    _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                }
            }

            inputDisplayText.text = _currentInput;

            if (Input.GetKeyDown(KeyCode.Return))
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
        }
        
        protected override bool CheckPuzzleComplete()
        {
            return _currentInput == targetCode;
        }
    }
}
