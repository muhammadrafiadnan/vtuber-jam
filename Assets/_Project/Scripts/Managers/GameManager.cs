using UnityEngine;
using Echoes.Events;
using Echoes.Pattern;

namespace Echoes.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("UI")] 
        [SerializeField] private GameObject gameWinPanel;
        [SerializeField] private GameObject gameLosePanel;
        
        public bool IsGameStart { get; private set; }
        
        private void OnEnable()
        {
            GameEvents.OnGameStart += GameStart;
            GameEvents.OnGameWin += GameWin;
            GameEvents.OnGameLose += GameLose;
        }
        
        private void OnDisable()
        {
            GameEvents.OnGameStart -= GameStart;
            GameEvents.OnGameWin -= GameWin;
            GameEvents.OnGameLose -= GameLose;
        }
        
        private void Start()
        {
            GameEvents.GameStartEvent();
        }

        // Core
        private void GameStart()
        {
            IsGameStart = true;
        }
        
        private void GameWin()
        {
            // Win
            IsGameStart = false;
            gameWinPanel.SetActive(true);
        }
        
        private void GameLose()
        {
            IsGameStart = false;
            gameLosePanel.SetActive(true);
        }
    }
}
