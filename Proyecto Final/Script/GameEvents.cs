using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<int, int, Transform> OnTartaCollected;
    public static Action OnLevelFinished;
    public static Action OnProgressUpdated;
    public static Action OnPlayerDied;
    public static Action OnPauseRequested;
    public static Action OnResumeRequested;
    public static Action OnPlayerJump;
    public static Action OnDrawStart;
    public static Action OnPlayerHit;
    public static Action OnCollectiblePicked;
}
