// [NUEVO SCRIPT] Bandit.cs
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public Animator animator;
    private bool isDead = false;
    [Header("Movimiento")]
    public float speed = 2f;
    public float distance = 0.5f;
    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!animator) animator = GetComponent<Animator>();
    }

     void Update()
    {
        if (isDead) return;
        float pingPong = Mathf.PingPong(Time.time * speed, distance);
        Vector3 targetOffset =new Vector3(pingPong, 0f, 0f);
        transform.position = startPosition + targetOffset;
        if (spriteRenderer)
        {
            float direction = Mathf.Sin(Time.time * speed);
            spriteRenderer.flipX = direction > 0;
        }
        if (animator)
            animator.SetBool("IsRunning", true);
    }

    public void Kill()
    {
        if (isDead) return;
        isDead = true;
        if (animator)
            animator.SetBool("Die", true);
        StartCoroutine(DeactivateAfterDelay(0.5f));
    }

    private System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
