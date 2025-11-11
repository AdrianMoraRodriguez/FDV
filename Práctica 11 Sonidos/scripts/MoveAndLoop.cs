using UnityEngine;

public class MoveAndLoop : MonoBehaviour
{
    public float speed = 10f;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            source.loop = true;
            source.Play();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            source.Stop();
        }

        if (source.isPlaying)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}