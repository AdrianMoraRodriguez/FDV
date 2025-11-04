using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform fondoActual;
    public Transform fondoAuxiliar;

    private float spriteWidth;
    private float cameraWidth;

    void Start()
    {
        // Usa la cámara principal si no se asignó
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // Ancho del sprite (basado en su tamaño en el mundo)
        spriteWidth = fondoActual.GetComponent<SpriteRenderer>().bounds.size.x;

        // Cálculo del ancho del encuadre de la cámara ortográfica
        Camera cam = Camera.main;
        float aspectRatio = cam.aspect;
        cameraWidth = cam.orthographicSize * 2f * aspectRatio;

        // Colocar el fondo auxiliar justo a la derecha del actual
        fondoAuxiliar.position = new Vector3(
            fondoActual.position.x + spriteWidth,
            fondoActual.position.y,
            fondoActual.position.z
        );
    }

    void Update()
    {
        // Verifica si la cámara alcanzó el borde derecho del fondo actual
        if (cameraTransform.position.x - cameraWidth / 2f > fondoActual.position.x + spriteWidth / 2f)
        {
            // Intercambiar roles
            Transform temp = fondoActual;
            fondoActual = fondoAuxiliar;
            fondoAuxiliar = temp;

            // Recolocar el nuevo fondo auxiliar justo a la derecha del actual
            fondoAuxiliar.position = new Vector3(
                fondoActual.position.x + spriteWidth,
                fondoActual.position.y,
                fondoActual.position.z
            );
            Debug.Log("Cambio a la derecha");
        }
        if (cameraTransform.position.x - cameraWidth / 2f < fondoActual.position.x - spriteWidth / 2f)
        {
            // Intercambiar roles
            Transform temp = fondoActual;
            fondoActual = fondoAuxiliar;
            fondoAuxiliar = temp;

            // Recolocar el nuevo fondo auxiliar justo a la izquierda del actual
            fondoActual.position = new Vector3(
                fondoAuxiliar.position.x - spriteWidth,
                fondoAuxiliar.position.y,
                fondoAuxiliar.position.z
            );
            Debug.Log("Cambio a la izquierda");
        }
    }
}
