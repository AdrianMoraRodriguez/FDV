using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public Vector2 moveDirection = Vector2.right;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyLimit"))
        {
            ReverseDirection();
        }
    }

    void ReverseDirection()
    {
        moveDirection = -moveDirection;
        if (moveDirection.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -(Mathf.Sign(moveDirection.x) * Mathf.Abs(scale.x));
            transform.localScale = scale;
        }
    }
}
