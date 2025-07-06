using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Echoes.Puzzle
{
    public class PipePuzzle : MonoBehaviour
    {
        float[] rotations = { 0, 90, 180, 270 };

        [SerializeField]
        private List<float> correctRotations = new List<float>();

        [SerializeField]
        bool isPlaced = false;

        private void Start()
        {
            if(IsCorrectRotation() && isPlaced == false)
            {
                isPlaced = true;
                PipeManager.singleton.CorrectMove();
            }
        }
        public void OnClick()
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if (IsCorrectRotation() && isPlaced == false)
            {
                isPlaced = true;
                PipeManager.singleton.CorrectMove();
            }
            else if(!IsCorrectRotation() && isPlaced == true)
            {
                isPlaced = false;
                PipeManager.singleton.WrongMove();
            }
        }
        bool IsCorrectRotation()
        {
            float currentZ = Mathf.Round(transform.eulerAngles.z % 360);
            foreach (float rot in correctRotations)
            {
                if (Mathf.Round(rot % 360) == currentZ)
                    return true;
            }
            return false;
        }

    }
}
