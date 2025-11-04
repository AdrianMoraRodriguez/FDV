using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action<Coin> OnCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
        }
    }
}
