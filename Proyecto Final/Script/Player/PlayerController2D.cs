using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;
    public PlayerDeath playerDeath;
    public int scale = 1;
    private bool canMove = false;
    private bool isPaused = false;
    private Animator animator;


    [Header("Attack")]
    public float inkCostAttack = 5f;
    public PoolOfAttack attackPool;
    public Transform attackSpawnPoint;
    public Transform centre;

    Rigidbody2D rb;
    bool isGrounded = false;

    void OnEnable()
    {
        GameEvents.OnPauseRequested += () => isPaused = true;
        GameEvents.OnResumeRequested += () => isPaused = false;
        GameMode.OnGameModeChanged += OnModeChanged;
    }

    void OnDisable()
    {
        GameEvents.OnPauseRequested -= () => isPaused = true;
        GameEvents.OnResumeRequested -= () => isPaused = false;
        GameMode.OnGameModeChanged -= OnModeChanged;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove) return;
        if (isPaused) return;
        CheckGround();
        Move();
        Jump();
        Attack();
    }

    private void OnModeChanged(bool isPlaying)
    {
        canMove = isPlaying;
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("IsJumping", !isGrounded);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
        if (x > 0) 
        {
            transform.localScale = new Vector3(scale, scale, scale);
            animator.SetBool("IsWalking", true);
        }
        else if (x < 0) 
        {
            transform.localScale = new Vector3(-scale, scale, scale);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            GameEvents.OnPlayerJump?.Invoke();
        }
    }


    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!InkSystem.Instance.TryConsume(inkCostAttack)) return;

            var attack = attackPool.Get();
            attack.transform.position = attackSpawnPoint.position;
            attack.transform.rotation = Quaternion.identity;

            var pooled = attack.GetComponent<AttackPooled>();
            Vector2 dir = attackSpawnPoint.position.x > centre.position.x ? Vector2.right : Vector2.left;
            pooled.Init(attackPool, dir);
        }
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Deadly") || collision.CompareTag("Enemy"))
    {
        canMove = false;
        GetComponent<SpriteRenderer>().enabled = false;
        foreach (Transform child in transform)
        {
            var sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = false;
            }
        }
        playerDeath.Die();
    }
  }


}
