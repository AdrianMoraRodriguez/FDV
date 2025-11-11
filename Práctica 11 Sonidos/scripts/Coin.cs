using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;
    public static event Action<Coin> OnCollected;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }
        }
    }
}
