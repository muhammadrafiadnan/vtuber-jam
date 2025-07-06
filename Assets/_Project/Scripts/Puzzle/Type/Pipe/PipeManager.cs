using UnityEngine;

namespace Echoes.Puzzle
{
    public class PipeManager : PuzzleBase
    {
        public GameObject pipeHolder;
        public GameObject[] Pipes;

        [SerializeField]
        int totalPipes, totalPipesTrue;

        int correctPipes;

        public static PipeManager singleton;

        protected override void InitOnStart()
        {
            base.InitOnStart();
            singleton = this;
            totalPipes = pipeHolder.transform.childCount;

            Pipes = new GameObject[totalPipes];

            for(int i = 0; i< Pipes.Length; i++)
            {
                Pipes[i] = pipeHolder.transform.GetChild(i).gameObject;
            }
        }

        protected override bool CheckPuzzleComplete()
        {
            return correctPipes == totalPipesTrue;
        }

        public void CorrectMove()
        {
            correctPipes += 1;
            if(CheckPuzzleComplete())
            {
                Debug.Log("Clear!");
                isPuzzleComplete = true;
                puzzleManager.CompletePuzzle();
                puzzleItem.ClearItem();
                ClosePuzzlePanel();
            }
        }
        public void WrongMove()
        {
            correctPipes -= 1;
        }
    }
}
