using UnityEngine;


public class Player : MonoBehaviour
{
  [Header("Movimiento")]
  public float moveSpeed = 5f;
  public float jumpVelocityBase = 10f;
  public float jumpVelocityBoosted = 15f;
  [Header("Referencias")]
  public Transform firePoint;
  private Rigidbody2D rb2D;
  private Animator animator;
  private SpriteRenderer spriteRenderer;
  private AudioSource audioSource;
  private bool isJumping = false;
  private float moveInput;

  [Header("Stats")]
  public int pointsForBoost = 100;
  public int currentPoints = 0;

  [Header("Sonidos")]
  public AudioClip jumpSound;
  public AudioClip landSound;
  public AudioClip moveSound;

  void Awake()
  {
    rb2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    rb2D.bodyType = RigidbodyType2D.Dynamic;
    rb2D.gravityScale = 3f;
    rb2D.freezeRotation = true;
    audioSource = GetComponent<AudioSource>();
    GameEvents.OnCollectiblePicked += HandleCollectiblePicked;
  }

  void Update()
  {
    moveInput = Input.GetAxisRaw("Horizontal");
    animator.SetBool("IsRunning", moveInput != 0);
    //animator.SetBool("IsJumping", isJumping);  // TODO: Implementar salto en animaciones
    if (moveInput < 0)
    {
      spriteRenderer.flipX = true;
      if (firePoint != null)
        firePoint.localPosition = new Vector3(-Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
    }
    else if (moveInput > 0)
    {
      spriteRenderer.flipX = false;
      if (firePoint != null)
        firePoint.localPosition = new Vector3(Mathf.Abs(firePoint.localPosition.x), firePoint.localPosition.y, 0);
    }
    if (Input.GetButtonDown("Jump") && !isJumping)
    {
      float jumpVelocity = (currentPoints >= pointsForBoost) ? jumpVelocityBoosted : jumpVelocityBase;
      rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpVelocity);
      isJumping = true;
      if (audioSource != null && jumpSound != null)
      {
        audioSource.PlayOneShot(jumpSound);
      }
    }
  }

  void FixedUpdate()
  {
    rb2D.linearVelocity = new Vector2(moveInput * moveSpeed, rb2D.linearVelocity.y);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("NoCollis"))
    {
      Debug.Log("Collided with NoCollis layer");
      return;
    }
    if (collision.gameObject.CompareTag("Ground"))
    {
      isJumping = false;
      if (audioSource != null && landSound != null)
      {
        audioSource.PlayOneShot(landSound);
      }
    }
    if (collision.gameObject.CompareTag("MovingPlatform"))
    {
      transform.SetParent(collision.transform);
      isJumping = false;
      if (audioSource != null && landSound != null)
      {
        audioSource.PlayOneShot(landSound);
      }
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("MovingPlatform"))
    {
      transform.SetParent(null);
    }
  }
  
  private void HandleCollectiblePicked(int points)
  {
    currentPoints += points;
  }

}
