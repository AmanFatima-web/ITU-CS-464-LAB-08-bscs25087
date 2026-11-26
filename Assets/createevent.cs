
using System;

public static class GameEvents
{
    public static event Action<int> Damaged;
    public static event Action Died;
    public static event Action Won;
    public static event Action Lost;
    public static event Action Paused;
    public static event Action Resumed;

    public static void OnDamaged(int health)
    {
        Damaged?.Invoke(health);
    }

    public static void OnDied()
    {
        Died?.Invoke();
    }

    public static void OnWon()
    {
        Won?.Invoke();
    }

    public static void OnLost()
    {
        Lost?.Invoke();
    }

    public static void OnPaused()
    {
        Paused?.Invoke();
    }

    public static void OnResumed()
    {
        Resumed?.Invoke();
    }
}
