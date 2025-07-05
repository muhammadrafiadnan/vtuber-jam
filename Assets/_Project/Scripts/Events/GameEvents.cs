using System;

namespace Echoes.Events
{
    public static class GameEvents
    {
        // Event
        public static event Action OnGameStart;
        public static event Action OnGameEnd;
        
        // Caller
        public static void GameStartEvent() => OnGameStart?.Invoke();
        public static void GameEndEvent() => OnGameEnd?.Invoke();
        
    }
}
