using UnityEngine;

public class MoveInWorldSpace : MonoBehaviour
{

    public Transform goal;
    public float speed = 1.0f;

    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

    }
}
