using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<int> OnCollectiblePicked;

    public static void CollectiblePicked(int points)
    {
        OnCollectiblePicked?.Invoke(points);
    }
}
