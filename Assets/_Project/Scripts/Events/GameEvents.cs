using System;

namespace Echoes.Events
{
    public static class GameEvents
    {
        // Event
        public static event Action OnGameStart;
        public static event Action OnGameDelay;
        public static event Action OnGameWin;
        public static event Action OnGameLose; 
        
        // Caller
        public static void GameStartEvent() => OnGameStart?.Invoke();
        public static void GameDelayEvent() => OnGameDelay?.Invoke();
        public static void GameWinEvent() => OnGameWin?.Invoke();
        public static void GameLoseEvent() => OnGameLose?.Invoke();
        
    }
}
