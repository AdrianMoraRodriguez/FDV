using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        [Range(0f, 1f)]
        public float parallaxFactor = 0.5f;
    }

    [Header("References")]
    public Transform cameraTransform;

    [Header("Layers")]
    public ParallaxLayer[] layers;

    [Header("Stability")]
    public float movementThreshold = 0.0001f;


    Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCameraPosition;

        if (delta.sqrMagnitude < movementThreshold * movementThreshold)
        {
            lastCameraPosition = cameraTransform.position;
            return;
        }

        foreach (var layer in layers)
        {
            if (layer.layer == null) continue;

            Vector3 move = new Vector3(
                delta.x * layer.parallaxFactor,
                delta.y * layer.parallaxFactor,
                0f
            );

            layer.layer.position += move;
        }

        lastCameraPosition = cameraTransform.position;
    }
}
