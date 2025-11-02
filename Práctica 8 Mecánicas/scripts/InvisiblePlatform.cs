using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

[RequireComponent(typeof(Tilemap), typeof(TilemapRenderer), typeof(Collider2D))]
public class InvisibleTilemapPlatform : MonoBehaviour
{
    [Header("Fade Settings")]
    public float fadeDuration = 0.5f; // Tiempo del efecto de fade
    public float visibleAlpha = 1f;   // Opacidad visible
    public float invisibleAlpha = 0f; // Opacidad inicial y al desaparecer

    private Tilemap tilemap;           // 🔹 Usamos Tilemap en lugar de TilemapRenderer
    private Collider2D col;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        SetTilemapAlpha(invisibleAlpha);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fadeRoutine != null)
                StopCoroutine(fadeRoutine);

            fadeRoutine = StartCoroutine(FadeTo(visibleAlpha));

            if (!col.enabled)
                col.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fadeRoutine != null)
                StopCoroutine(fadeRoutine);

            fadeRoutine = StartCoroutine(FadeTo(invisibleAlpha));
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = tilemap.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            SetTilemapAlpha(newAlpha);
            yield return null;
        }

        SetTilemapAlpha(targetAlpha);
    }

    private void SetTilemapAlpha(float alpha)
    {
        if (tilemap != null)
        {
            Color c = tilemap.color;
            c.a = alpha;
            tilemap.color = c;
        }
    }
}
