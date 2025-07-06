using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

namespace Echoes.Puzzle
{
    public class PipeManager : MonoBehaviour
    {
        public GameObject pipeHolder;
        public GameObject[] Pipes;

        [SerializeField]
        int totalPipes, totalPipesTrue;

        int correctPipes;

        public static PipeManager singleton;

        private void Start()
        {
            singleton = this;
            totalPipes = pipeHolder.transform.childCount;

            Pipes = new GameObject[totalPipes];

            for(int i = 0; i< Pipes.Length; i++)
            {
                Pipes[i] = pipeHolder.transform.GetChild(i).gameObject;
            }
        }
        public void CorrectMove()
        {
            correctPipes += 1;

            if(correctPipes == totalPipesTrue)
            {
                Debug.Log("Clear!");
            }
        }
        public void WrongMove()
        {
            correctPipes -= 1;
        }
    }
}
