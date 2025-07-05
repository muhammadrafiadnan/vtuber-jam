using UnityEngine;
using Echoes.Events;
using Echoes.Pattern;

namespace Echoes.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsGameStart { get; private set; }

        private void OnEnable()
        {
            GameEvents.OnGameStart += GameStart;
            GameEvents.OnGameEnd += GameEnd;
        }
        
        private void OnDisable()
        {
            GameEvents.OnGameStart -= GameStart;
            GameEvents.OnGameEnd -= GameEnd;
        }

        private void Start()
        {
            IsGameStart = false;
        }

        private void GameStart()
        {
            IsGameStart = true;
        }

        private void GameEnd()
        {
            IsGameStart = false;
        }
    }
}
