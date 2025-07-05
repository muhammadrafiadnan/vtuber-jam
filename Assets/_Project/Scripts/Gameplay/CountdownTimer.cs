using UnityEngine;
using TMPro;
using Echoes.Events;

namespace Echoes.Gameplay
{
    public class CountdownTimer : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] [Tooltip("Isi dalam jumlah detik")] private float time;
        [SerializeField] private TextMeshProUGUI timeTextUI;

        private float _currentTime;

        private void Start()
        {
            _currentTime = time;
        }
        
        private void Update()
        {
            HandleTimer();
            HandleTimerText();
        }
        
        private void HandleTimer()
        {
            if (_currentTime == 0f) return;
            
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0f)
            {
                _currentTime = 0f;
                GameEvents.GameLoseEvent();
            }
        }
        
        private void HandleTimerText()
        {
            var minute = Mathf.FloorToInt(_currentTime / 60f);
            var second = Mathf.FloorToInt(_currentTime % 60f);
            
            timeTextUI.text = $"{minute:00}:{second:00}";
        }
    }
}
