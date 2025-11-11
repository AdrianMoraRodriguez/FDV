using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource impactSource;
    public AudioClip impactClip;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            impactSource.PlayOneShot(impactClip);
        }
    }
}
