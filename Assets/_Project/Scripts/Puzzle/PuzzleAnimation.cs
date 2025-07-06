using UnityEngine;
using DG.Tweening;

namespace Echoes.Puzzle
{
    public class PuzzleAnimation : MonoBehaviour
    {
        [Header("Animation")] 
        [SerializeField] private float tweenDuration;
        [SerializeField] private float bounceDuration;
        [SerializeField] private Ease easeType;
        [SerializeField] private Vector3 targetScale;
        [SerializeField] private Vector3 upperScale;
        
        private Vector3 _originalScale;
        
        // Reference
        private RectTransform _rect;
        
        public void AnimateInPuzzle(GameObject panel, TweenCallback callback)
        {
            if (_rect == null)
                _rect = panel.GetComponent<RectTransform>();
            
            _rect.localScale = Vector3.zero;
            _rect.DOScale(upperScale, tweenDuration).SetEase(easeType);
            _rect.DOScale(targetScale, bounceDuration).SetEase(easeType)
                .SetDelay(tweenDuration)
                .OnComplete(callback);
        }
        
        public void AnimateOutPuzzle(TweenCallback callback)
        {
            _rect.DOScale(upperScale, bounceDuration).SetEase(easeType);
            _rect.DOScale(_originalScale, tweenDuration).SetEase(easeType)
                .SetDelay(bounceDuration)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                    gameObject.SetActive(false);
                });
        }
        
    }
}