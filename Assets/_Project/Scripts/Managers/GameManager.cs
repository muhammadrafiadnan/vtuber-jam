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
            IsGameStart = false;
        }
        
        private void GameStart()
        {
            IsGameStart = true;
        }
        
        private void GameWin()
        {
            IsGameStart = false;
        }

        private void GameLose()
        {
            IsGameStart = false;
        }
    }
}
