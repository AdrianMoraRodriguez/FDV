using UnityEngine;

public class DopplerMover : MonoBehaviour
{
    public float speed = 30f;
    private bool moving = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            moving = !moving;
        } else if (Input.GetKeyDown(KeyCode.B)){
            moving = false;
        }

        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } else {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
