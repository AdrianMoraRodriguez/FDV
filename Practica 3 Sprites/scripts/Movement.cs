using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
  public float speed = 5.0f;
  private SpriteRenderer spriteRenderer;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    Vector2 movement = new Vector2(horizontal, 0f);
    transform.Translate(movement * speed * Time.deltaTime);
    if (horizontal != 0) {
      GetComponent<Animator>().SetBool("Run", true);
    } else {
      GetComponent<Animator>().SetBool("Run", false);
    }

    if (horizontal > 0)
      {
        spriteRenderer.flipX = false;
      }
      else if (horizontal < 0)
      {
        spriteRenderer.flipX = true;
      }
        
  }
}
