using System;
using System.Collections;
using UnityEngine;

namespace Echoes.Entities
{
    public class SurvivorAI : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private string survivorName;
        [SerializeField] private SurvivorState currentState;
        [SerializeField] private bool isFacingRight;
        
        public bool IsFacingRight => isFacingRight;
        
        [Header("Reference")]
        [SerializeField] private Animator survivorAnim;
        
        // Methods
        private void Start()
        {
            gameObject.name = survivorName;
            currentState = SurvivorState.Idle;
        }
        
        private void ChangeState(SurvivorState newState)
        {
            if (newState == currentState) return;
            
            var state = GetState(newState);
            survivorAnim.CrossFade(state, 0, 0);
            currentState = newState;
        }
        
        public IEnumerator MoveToPointRoutine(float duration, Vector2 point, Action callback = null)
        {
            ChangeState(SurvivorState.Run);
            var targetPos = new Vector2(point.x, transform.position.y);
            
            while (Vector2.Distance(transform.position, targetPos) > 0.1f)
            {
                var t = duration * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, t);
                yield return null;
            }

            transform.position = targetPos;
            ChangeState(SurvivorState.Idle);
            callback?.Invoke();
        }
        
        public void CheckDirection(float targetX)
        {
            var survivorX = transform.position.x;

            var shouldFaceRight = targetX > survivorX;
            if (shouldFaceRight != isFacingRight)
                Flip();
        }
        
        private void Flip()
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        
        private int GetState(SurvivorState state)
        {
            return state switch
            {
                SurvivorState.Idle => Animator.StringToHash("Idle"),
                SurvivorState.Run => Animator.StringToHash("Run"),
                _ => throw new InvalidOperationException("Invalid survivor state")
            };
        }
    }
}
