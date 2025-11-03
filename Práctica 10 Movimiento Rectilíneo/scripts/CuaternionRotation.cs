using UnityEngine;

public class CuaternionRotation : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float accuracy = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction.magnitude > accuracy)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
