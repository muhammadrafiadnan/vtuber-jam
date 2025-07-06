using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Echoes.Puzzle
{
    public class CodePuzzle : PuzzleBase
    {
        [Header("Attributes")]
        [SerializeField] private string correctCode;
        [SerializeField] private TextMeshProUGUI codeTextUI;
        [SerializeField] private Color rightColor;
        [SerializeField] private Color wrongColor;
        
        private bool _canAddDigit;
        private string _codeTextValue = "";
        
        // Initialize
        protected override void InitOnStart()
        {
            base.InitOnStart();
            _canAddDigit = true;
            codeTextUI.text = _codeTextValue;
        }
        
        // Core
        public void AddDigit(string digit)
        {
            if (!_canAddDigit || isPuzzleComplete || _codeTextValue.Length > correctCode.Length) return;
            
            _codeTextValue += digit;
            codeTextUI.text = _codeTextValue;
            if (_codeTextValue.Length >= correctCode.Length)
            {
                SubmitCode();
            }
        }
        
        public void ClearCode()
        {
            _codeTextValue = "";
            codeTextUI.text = _codeTextValue;
        }
        
        private IEnumerator AnimateRightText()
        {
            _canAddDigit = false;
            codeTextUI.color = rightColor;
            yield return new WaitForSeconds(0.5f);
            
            isPuzzleComplete = true;
            puzzleItem.ClearItem();
            ClosePuzzlePanel();
        }
        
        private IEnumerator AnimateWrongText()
        {
            _canAddDigit = false;
            codeTextUI.color = wrongColor;
            codeTextUI.transform.DOShakePosition(0.3f, new Vector3(1.3f, 0f, 0f), 50);
            yield return new WaitForSeconds(0.6f);
            
            _canAddDigit = true;
            codeTextUI.color = Color.black;
            ClearCode();
        }
        
        public void SubmitCode()
        {
            if (CheckPuzzleComplete())
            {
                Debug.Log("puzzle clear!");
                StartCoroutine(AnimateRightText());
            }
            else
            {
                Debug.Log("wrong code bro!");
                StartCoroutine(AnimateWrongText());
            }
        }

        protected override bool CheckPuzzleComplete()
        {
            return _codeTextValue == correctCode;
        }
        
        protected override void ResetPuzzle()
        {
            base.ResetPuzzle();
            ClearCode();
        }
    }
}
