using UnityEngine;
using TMPro;
using System;

namespace Echoes.Puzzle
{
    public class NumberCode : MonoBehaviour
    {
        public GameObject NumberPad;
        private SpriteRenderer spriteRenderer;

        [SerializeField] private TextMeshProUGUI codeText;
        [SerializeField] private string correctCode;

        string codeTextValue = "";

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            UpdateDisplay();
        }

        public void OnMouseDown()
        {
            NumberPad.SetActive(true);
        }

        public void AddDigit(string digit)
        {
            if (codeTextValue.Length < correctCode.Length)
            {
                codeTextValue += digit;
                UpdateDisplay();
            }
        }
        public void ClearCode()
        {
            codeTextValue = "";
            UpdateDisplay();
        }
        public void SubmitCode()
        {
            if(codeTextValue == correctCode)
            {
                Debug.Log("Clear!!");
            }
            else
            {
                Debug.Log("Wrong Code!");
            }
        }
        private void UpdateDisplay()
        {
            codeText.text = codeTextValue;
        }
    }
}
