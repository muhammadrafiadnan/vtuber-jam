using System.Collections;
using UnityEngine;
using Echoes.Events;
using Echoes.Entities;

namespace Echoes.Puzzle
{
    public class PuzzleManager : MonoBehaviour
    {
        [Header("Puzzle")]
        [SerializeField] private PuzzleBase[] puzzles;
        private int _clearPuzzleCount;
        
        [Header("Sequence")] 
        [SerializeField] private Animator doorAnimator;
        [SerializeField] private SurvivorAI[] survivors;
        
        private const string OPEN_DOOR = "Open";
        
        // Unity Callbacks
        private void Start()
        {
            _clearPuzzleCount = 0;
            foreach (var puzzle in puzzles)
            {
                puzzle.gameObject.SetActive(false);
                puzzle.InjectManager(this);
            }
        }

        // Core
        public void CompletePuzzle()
        {
            _clearPuzzleCount++;
            if (_clearPuzzleCount >= puzzles.Length)
               StartCoroutine(TriggerCompleteSequence());
        }
        
        private IEnumerator TriggerCompleteSequence()
        {
            yield return new WaitForSeconds(0.5f);
            doorAnimator.SetTrigger(OPEN_DOOR);
            var animationTime = doorAnimator.GetCurrentAnimatorClipInfo(0).Length;
            
            yield return new WaitForSeconds(animationTime);
            
            var doorPos = doorAnimator.transform.position;
            foreach (var survivor in survivors)
            {
                survivor.CheckDirection(doorPos.x);
                yield return new WaitForSeconds(0.25f);
                
                yield return survivor.MoveToPointRoutine(5.5f, doorPos, () =>
                {
                    survivor.gameObject.SetActive(false);
                });
            }
            
            GameEvents.GameWinEvent();
        }
            
    }
}