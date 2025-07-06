using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Echoes.Puzzle
{
    public class PipePuzzle : MonoBehaviour
    {
        float[] rotations = { 0, 90, 180, 270 };

        public float correctRotation;
        [SerializeField]
        bool isPlaced = false;

        private void Start()
        {
            if(transform.eulerAngles.z == correctRotation)
            {
                isPlaced = true;
                PipeManager.singleton.CorrectMove();
            }
        }
        public void OnClick()
        {
            transform.Rotate(new Vector3(0, 0, 90));
            if(transform.eulerAngles.z == correctRotation && isPlaced == false)
            {
                isPlaced = true;
                PipeManager.singleton.CorrectMove();
            }
            else if(isPlaced == true)
            {
                isPlaced = false;
                PipeManager.singleton.WrongMove();
            }
        }
    }
}
