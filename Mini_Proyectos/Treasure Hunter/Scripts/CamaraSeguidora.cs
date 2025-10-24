using UnityEngine;

public class CamaraSeguidora : MonoBehaviour
{
    public Transform jugador;  // Arrastra tu jugador aquí
    public float suavizado = 0.1f;  // Qué tan suave se mueve la cámara
    public Vector3 offset = new Vector3(0, 0, -10); // Para que la cámara quede detrás en Z

    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        if (jugador == null) return;

        // Posición deseada
        Vector3 objetivo = jugador.position + offset;

        // Suavizado con SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, objetivo, ref velocidad, suavizado);
    }
}
