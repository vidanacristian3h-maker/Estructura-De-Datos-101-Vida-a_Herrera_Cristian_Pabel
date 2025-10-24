using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class Tesoro : MonoBehaviour
{
    public bool contieneLlave = false;
    private bool abierto = false;
    private bool jugadorCerca = false;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteAbierto;
    private Inventario inventarioJugador;

    [Header("UI")]
    public TextMeshProUGUI textoMiniMensaje; // Texto flotante temporal
    public TextMeshProUGUI textoPuntaje;     // Texto fijo de puntaje en HUD

    // Loot disponible por nivel
    private static List<(string nombre, int valor)> itemsDisponiblesNivel;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Inicializar loot del nivel si no existe
        if (itemsDisponiblesNivel == null || itemsDisponiblesNivel.Count == 0)
        {
            itemsDisponiblesNivel = new List<(string, int)>
            {
                ("Moneda de oro 🪙", 10),
                ("Gema 💎", 25),
                ("Poción de energía 🍷", 15),
                ("Reloj antiguo ⏱", 20)
            };
        }
    }

    void Update()
    {
        if (jugadorCerca && !abierto && Input.GetKeyDown(KeyCode.E))
        {
            AbrirCofre();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            inventarioJugador = other.GetComponent<Inventario>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            inventarioJugador = null;
        }
    }

    private void AbrirCofre()
    {
        if (abierto || inventarioJugador == null) return;

        string lootNombre;
        int lootValor;

        if (contieneLlave)
        {
            lootNombre = "Llave de salida 🔑";
            lootValor = 999;
            StartCoroutine(MostrarMiniMensaje("¡Agarraste una llave!"));
        }
        else
        {
            if (itemsDisponiblesNivel.Count == 0)
            {
                lootNombre = "Nada";
                lootValor = 0;
                StartCoroutine(MostrarMiniMensaje("¡Cofre vacío!"));
            }
            else
            {
                int index = Random.Range(0, itemsDisponiblesNivel.Count);
                (lootNombre, lootValor) = itemsDisponiblesNivel[index];
                itemsDisponiblesNivel.RemoveAt(index); // no repetir
                StartCoroutine(MostrarMiniMensaje($"¡Agarraste {lootNombre}!"));
            }
        }

        inventarioJugador.AgregarItem(lootNombre, lootValor);

        // Sumar puntos al jugador
        if (GameData.instancia != null)
        {
            GameData.instancia.puntuacionJugador += lootValor;
            ActualizarPuntajeHUD();
        }

        // Actualizar UI del inventario
        UIInventario ui = FindObjectOfType<UIInventario>();
        if (ui != null)
            ui.ActualizarLista();

        // Cambiar sprite o destruir cofre
        if (spriteAbierto != null && spriteRenderer != null)
            spriteRenderer.sprite = spriteAbierto;
        else
            Destroy(gameObject);

        abierto = true;
    }

    private IEnumerator MostrarMiniMensaje(string mensaje)
    {
        if (textoMiniMensaje == null) yield break;

        textoMiniMensaje.text = mensaje;
        textoMiniMensaje.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); // Mostrar 2 segundos

        textoMiniMensaje.gameObject.SetActive(false);
    }

    private void ActualizarPuntajeHUD()
    {
        if (textoPuntaje != null && GameData.instancia != null)
            textoPuntaje.text = $"Puntaje: {GameData.instancia.puntuacionJugador}";
    }
}
