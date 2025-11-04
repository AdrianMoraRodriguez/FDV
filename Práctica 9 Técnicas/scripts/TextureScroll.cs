using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float scrollSpeed = 0.2f;

    private Material mat;
    private Vector2 offset;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (mat == null)
        {
            Debug.LogError("No material found on the Renderer component.");
        } else
    {
      Debug.Log("Material found: " + mat.name);
    }
    }

    void Update()
    {
        offset += new Vector2(scrollSpeed * Time.deltaTime, 0);
        mat.SetTextureOffset("_MainTex", offset);
    }
}
