using System;

namespace Echoes.Events
{
    public static class TimeEvents
    {
        // Event
        public static event Action OnTimerReStarted;
        public static event Action OnTimerEnded;

        // Caller
        public static void TimerReStartedEvent() => OnTimerReStarted?.Invoke();
        public static void TimerEndedEvent() => OnTimerEnded?.Invoke();
    }
}