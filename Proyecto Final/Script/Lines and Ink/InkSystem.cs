using UnityEngine;
using System;

public class InkSystem : MonoBehaviour
{
    public static InkSystem Instance;

    [Header("Ink Settings")]
    public float maxInk = 100f;
    public float currentInk = 100f;

    // (valor normalizado 0–1)
    public event Action<float> OnInkChanged;

    private void Awake()
    {
        Instance = this;
        currentInk = maxInk;
    }

    public bool TryConsume(float amount)
    {
        if (currentInk <= 0f) return false;

        currentInk -= amount;
        currentInk = Mathf.Clamp(currentInk, 0, maxInk);

        OnInkChanged?.Invoke(currentInk / maxInk);
        return true;
    }

    public void ResetInk()
    {
        currentInk = maxInk;
        OnInkChanged?.Invoke(1f);
    }
}
