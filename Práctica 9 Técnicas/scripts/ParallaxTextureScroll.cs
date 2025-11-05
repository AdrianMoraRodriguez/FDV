using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ParallaxTextureScroll : MonoBehaviour
{
    [Header("Velocidad base del scroll")]
    public float speedOffset = 0.1f;

    [Header("Dirección de movimiento")]
    public Vector2 movement = Vector2.right;

    private Material[] layers;

    void Start()
    {
        // Recuperar todos los materiales del Renderer
        layers = GetComponent<Renderer>().materials;
    }

    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            Material m = layers[i];
            Vector2 offset = m.GetTextureOffset("_MainTex");
            offset += (speedOffset * movement * Time.deltaTime) / (i + 1.0f);
            m.SetTextureOffset("_MainTex", offset);
        }
    }
}
