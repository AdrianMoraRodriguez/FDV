using UnityEngine;

public class MovementConsistent : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition.position.normalized * speed * Time.deltaTime);
    }
}
