using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private SpriteRenderer sr;
    private Animator animator;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 delta = new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(delta, Space.World);
        if (horizontal != 0)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);
        if (horizontal > 0)
            sr.flipX = false;
        else if (horizontal < 0)
            sr.flipX = true;
    }
}
