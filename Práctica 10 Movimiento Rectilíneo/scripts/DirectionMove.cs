using UnityEngine;

public class DirectionMove : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.LookAt(target);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
