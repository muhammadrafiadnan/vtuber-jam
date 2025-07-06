using TMPro;
using UnityEngine;

namespace Echoes.Puzzle
{
    public class MorsePuzzle : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI inputDisplayText;

        [SerializeField] private string targetCode = "OPEN";

        [SerializeField] private int maxInputLength;

        private string currentInput = "";

        void Update()
        {
            foreach (char key in Input.inputString)
            {
                if (char.IsLetterOrDigit(key) && currentInput.Length < maxInputLength)
                {
                    currentInput += char.ToUpper(key);
                }
                else if (key == '\b' && currentInput.Length > 0)
                {
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                }
            }

            inputDisplayText.text = currentInput;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CheckInputCode();
            }
        }

        void CheckInputCode()
        {
            if (currentInput == targetCode)
            {
                Debug.Log("Clear!");
            }
            else
            {
                Debug.Log("Wrong Code!");
            }
        }
    }
}
