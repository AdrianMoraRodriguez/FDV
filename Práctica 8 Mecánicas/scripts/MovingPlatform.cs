using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 2f;
    private Vector3 target;

    void Start()
    {
        startPoint = transform.position;
        target = endPoint;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, target) < 0.05f) {
            target = (target == endPoint) ? startPoint : endPoint;
        }
    }
}
