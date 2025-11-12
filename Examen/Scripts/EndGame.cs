using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{

    private Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Open", true);
            Debug.Log("¡Has llegado al final del juego!");
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
}
