using Echoes.Events;
using UnityEngine;
using TMPro;

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
                GameEvents.GameEndEvent();
            }
        }
        
        private void HandleTimerText()
        {
            var minute = Mathf.FloorToInt(time / 60f);
            var second = Mathf.FloorToInt(time % 60f);
            
            timeTextUI.text = $"{minute:00}:{second:00}";
        }
    }
}
