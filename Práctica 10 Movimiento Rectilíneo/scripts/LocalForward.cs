using UnityEngine;

public class LocalForward : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
