using System;
using UnityEngine;
using TMPro;
using Echoes.Events;
using Echoes.Managers;

namespace Echoes.Gameplay
{
    public class CountdownTimer : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] [Tooltip("Isi dalam jumlah detik")] private float time;
        [SerializeField] private float decreasedTime;
        [SerializeField] private TextMeshProUGUI timeTextUI;
        
        private float _currentTime;
        
        private void OnEnable()
        {
            TimeEvents.OnTimerReStarted += ModifyTimeAfterDie;
        }
        
        private void OnDisable()
        {
            TimeEvents.OnTimerReStarted -= ModifyTimeAfterDie;
        }

        private void Start()
        {
            _currentTime = time;
        }
        
        private void Update()
        {
            if (!GameManager.Instance.IsGameStart) return;
            if (_currentTime == 0f) return;
            
            HandleTimer();
            HandleTimerText();
        }
        
        private void HandleTimer()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0f)
            {
                _currentTime = 0f;
                GameEvents.GameDelayEvent();
                TimeEvents.TimerEndedEvent();
            }
        }
        
        private void HandleTimerText()
        {
            var minute = Mathf.FloorToInt(_currentTime / 60f);
            var second = Mathf.FloorToInt(_currentTime % 60f);
            
            timeTextUI.text = $"{minute:00}:{second:00}";
        }

        private void ModifyTimeAfterDie()
        {
            _currentTime = time;
            _currentTime -= decreasedTime;
        }
    }
}
