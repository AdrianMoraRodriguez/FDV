using UnityEngine;

public class StopWithDistance : MonoBehaviour
{
    public Transform target;
    public float stopDistance = 0.1f;
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.LookAt(target);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
