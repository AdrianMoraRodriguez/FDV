using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    [Header("Cámara a seguir")]
    public Transform cameraTransform;

    [Header("Capas del parallax (más cercanas primero)")]
    public Transform[] layers;

    [Header("Factor base de velocidad")]
    public float baseSpeed = 0.5f;

    private Vector3 lastCamPos;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCamPos;

        for (int i = 0; i < layers.Length; i++)
        {
            float parallaxFactor = baseSpeed / (i + 1f);
            layers[i].position -= new Vector3(delta.x * parallaxFactor, 0f, 0f);
        }

        lastCamPos = cameraTransform.position;
    }
}
