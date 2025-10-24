using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPartida : MonoBehaviour
{
    public JugadorStats jugadorStats;
    public Inventario inventarioJugador;

    void Start()
    {
        SaveData data = SaveSystem.Cargar();
        if (data == null) return;

        // Restaurar estadísticas
        jugadorStats.puntuacionTotal = data.puntuacionTotal;
        jugadorStats.SetVidas(data.vidasRestantes); // usa el método público

        // Restaurar inventario: usar AgregarItem (usa el constructor interno del Inventario)
        inventarioJugador.items.Clear();
        for (int i = 0; i < data.nombresItems.Count; i++)
        {
            string nombre = data.nombresItems[i];
            int valor = data.valoresItems[i];
            inventarioJugador.AgregarItem(nombre, valor); // usa API pública
        }

        Debug.Log("✅ Partida restaurada: " +
                  $"Vidas={jugadorStats.vidas}, Puntos={jugadorStats.puntuacionTotal}, Items={inventarioJugador.items.Count}");
    }
}
