using UnityEngine;

public class CollisionVolume : MonoBehaviour
{
    public AudioSource source;
    public AudioClip impactClip;

    void OnCollisionEnter(Collision collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;
        float volume = Mathf.Clamp01(impactForce / 10f);
        source.PlayOneShot(impactClip, volume);
    }
}
