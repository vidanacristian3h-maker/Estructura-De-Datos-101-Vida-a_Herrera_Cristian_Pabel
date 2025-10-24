using UnityEngine;
using TMPro;

public class UIInventario : MonoBehaviour
{
    public GameObject panelInventario;
    public TextMeshProUGUI textoItems;

    private Inventario inventarioJugador;

    void Update()
    {
        // 1️⃣ Buscar el inventario del jugador si es null
        if (inventarioJugador == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
                inventarioJugador = jugador.GetComponent<Inventario>();
        }

        // 2️⃣ Abrir/cerrar inventario con tecla I
        if (Input.GetKeyDown(KeyCode.I) && inventarioJugador != null)
        {
            bool visible = !panelInventario.activeSelf;
            panelInventario.SetActive(visible);

            if (visible)
                ActualizarLista();
        }
    }

    // Llamar desde Tesoro.cs al abrir un cofre
    public void ActualizarLista()
    {
        if (inventarioJugador == null || textoItems == null) return;

        // Ordenar ítems por valor (mayor a menor)
        inventarioJugador.items.Sort((a, b) => b.valor.CompareTo(a.valor));

        textoItems.text = "📦 INVENTARIO:\n";

        foreach (var item in inventarioJugador.items)
        {
            textoItems.text += $"• {item.nombre} — valor {item.valor}\n";
        }

        if (inventarioJugador.items.Count == 0)
            textoItems.text += "No hay items.";
    }
}
