using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    private Inventario inventarioJugador;
    private JugadorStats jugadorStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventarioJugador = other.GetComponent<Inventario>();
            jugadorStats = other.GetComponent<JugadorStats>(); // ✅ ahora sí tenemos la referencia al jugador

            Debug.Log("🚪 Presiona [E] para escapar");
        }
    }

    void Update()
    {
        if (inventarioJugador != null && Input.GetKeyDown(KeyCode.E))
        {
            IntentarEscapar();
        }
    }

    private void IntentarEscapar()
    {
        if (inventarioJugador == null)
        {
            Debug.LogWarning("Inventario del jugador es null");
            return;
        }

        if (GameData.instancia == null)
        {
            Debug.LogWarning("GameData.instancia es null");
            return;
        }

        bool tieneLlave = inventarioJugador.items.Exists(i => i.nombre.Contains("Llave"));

        if (tieneLlave)
        {
            Debug.Log("🎉 ¡Has escapado del laberinto!");

            // Crear objeto de guardado
            SaveData data = new SaveData();
            data.nivelActual = SceneManager.GetActiveScene().buildIndex;
            data.puntuacionTotal = jugadorStats.puntuacionTotal;
            data.vidasRestantes = jugadorStats.vidas;
            data.tiempoTotal = Time.timeSinceLevelLoad;

            // Guardar inventario
            foreach (var item in inventarioJugador.items)
            {
                data.nombresItems.Add(item.nombre);
                data.valoresItems.Add(item.valor);
            }

            SaveSystem.Guardar(data);

            // Pasar a escena de victoria
            SceneManager.LoadScene("Victoria");
        }
        else
        {
            Debug.Log("🔒 Necesitas una llave para abrir la salida");
        }
    }

}
