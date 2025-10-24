using UnityEngine;

public class Trampa : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la trampa
        {
            // Buscar el componente JugadorStats
            JugadorStats jugadorStats = other.GetComponent<JugadorStats>();

            if (jugadorStats != null)
            {
                // Aplicar daño directamente (esto ya maneja vidas, energía y eventos)
                jugadorStats.RecibirDañoDeTrampa();

                Debug.Log("💥 Trampa activada, daño aplicado al jugador");

                // 🔹 Mostrar panel de vida perdida usando el sistema de eventos
                UIStats ui = FindObjectOfType<UIStats>();
                if (ui != null)
                {
                    // Forzar que actualice con el jugador actual
                    ui.SetJugador(jugadorStats);
                }
            }
        }
    }
}
