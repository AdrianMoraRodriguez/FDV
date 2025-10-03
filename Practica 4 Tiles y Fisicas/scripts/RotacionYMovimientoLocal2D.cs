using UnityEngine;

public class RotacionYMovimientoLocal2D : MonoBehaviour
{
    public float moveSpeed = 4f;

    public float rotationSpeed = 180f;

    void Update()
    {
        float rotInput = Input.GetAxis("Horizontal");
        float moveInput = Input.GetAxis("Vertical");
        float deltaAngle = rotInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -deltaAngle);
        Vector3 localForward = Vector3.up;
        Vector3 localDelta = localForward * (moveInput * moveSpeed * Time.deltaTime);
        transform.Translate(localDelta, Space.Self);
    }
}
