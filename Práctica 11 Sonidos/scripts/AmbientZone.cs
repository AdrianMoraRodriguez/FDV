using UnityEngine;

public class AmbientZone : MonoBehaviour
{
    public AudioClip newClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource ambient = GetComponent<AudioSource>();
            if (ambient.clip != newClip)
            {
                ambient.clip = newClip;
                ambient.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource ambient = GetComponent<AudioSource>();
            ambient.Stop();
            ambient.clip = null;
        }
    }
}
