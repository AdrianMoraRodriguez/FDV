using UnityEngine;

public class BackgroundScrollA : MonoBehaviour
{
    public Transform fondoActual;
    public Transform fondoAuxiliar;
    public float scrollSpeed = 2f;

    private float spriteWidth;
    private Vector3 posInicial;

    void Start()
    {
        spriteWidth = fondoActual.GetComponent<SpriteRenderer>().bounds.size.x;
        posInicial = fondoActual.position;
    }

    void Update()
    {
        fondoActual.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        fondoAuxiliar.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        if (fondoActual.position.x < posInicial.x - spriteWidth)
        {
            Transform temp = fondoActual;
            fondoActual = fondoAuxiliar;
            fondoAuxiliar = temp;
            fondoAuxiliar.position = new Vector3(fondoActual.position.x + spriteWidth, fondoActual.position.y, fondoActual.position.z);
            posInicial = fondoActual.position;
        }
    }
}
