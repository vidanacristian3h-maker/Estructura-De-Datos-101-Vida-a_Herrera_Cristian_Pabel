using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIVictoria : MonoBehaviour
{
    public TextMeshProUGUI textoInventarioFinal;
    public TextMeshProUGUI textoEstadisticas;
    public TMP_InputField inputNombreJugador; // Para que el jugador ponga su nombre

    private int ultimoNivel = 3; // Cambia según tu juego

    void Start()
    {
        MostrarInventario();
        MostrarEstadisticas();
    }

    private void MostrarInventario()
    {
        if (GameData.instancia != null && textoInventarioFinal != null)
        {
            textoInventarioFinal.text = "🎉 Ítems obtenidos:\n";
            if (GameData.instancia.itemsJugador.Count > 0)
            {
                foreach (var item in GameData.instancia.itemsJugador)
                    textoInventarioFinal.text += $"• {item.nombre} — valor {item.valor}\n";
            }
            else
                textoInventarioFinal.text += "Sin objetos recolectados\n";
        }
    }

    private void MostrarEstadisticas()
    {
        SaveData data = SaveSystem.Cargar();
        if (data != null && textoEstadisticas != null)
        {
            textoEstadisticas.text =
                $"Nivel alcanzado: {data.nivelActual}\n" +
                $"Puntuación total: {data.puntuacionTotal}\n" +
                $"Vidas restantes: {data.vidasRestantes}\n" +
                $"Tiempo total: {data.tiempoTotal:F1} segundos";
        }
    }

    public void Click_SiguienteNivel()
    {
        if (GameData.instancia == null) return;

        int siguienteNivel = GameData.instancia.nivelActualJugador + 1;

        if (siguienteNivel > ultimoNivel)
        {
            Debug.Log("🎉 Has completado todos los niveles. Volviendo al menú principal.");

            // 🏆 Guardar ranking antes de volver al menú
            GuardarRanking();

            // También guardamos progreso final si quieres conservarlo
            SaveData data = new SaveData
            {
                nivelActual = GameData.instancia.nivelActualJugador,
                puntuacionTotal = GameData.instancia.puntuacionJugador,
                vidasRestantes = GameData.instancia.vidasJugador,
                tiempoTotal = Time.timeSinceLevelLoad
            };
            SaveSystem.Guardar(data);

            SceneManager.LoadScene(0);
            return;
        }

        GameData.instancia.nivelActualJugador = siguienteNivel;
        Debug.Log($"🔜 Cargando siguiente nivel: {siguienteNivel}");
        SceneManager.LoadScene(siguienteNivel);
    }


    public void Click_GuardarYSalir()
    {
        GuardarRanking(); // 🔥 Guardamos ranking antes de salir

        // Guardar progreso normal
        SaveData data = new SaveData
        {
            nivelActual = GameData.instancia.nivelActualJugador,
            puntuacionTotal = GameData.instancia.puntuacionJugador,
            vidasRestantes = GameData.instancia.vidasJugador,
            tiempoTotal = Time.timeSinceLevelLoad
        };
        SaveSystem.Guardar(data);

        // Volver al menú
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void GuardarRanking()
    {
        string nombre = "Jugador";
        if (inputNombreJugador != null && !string.IsNullOrEmpty(inputNombreJugador.text))
            nombre = inputNombreJugador.text;

        RegistroJugador registro = new RegistroJugador(
            nombre,
            GameData.instancia.nivelActualJugador,
            GameData.instancia.puntuacionJugador
        );

        Ranking.AgregarRegistro(registro);
        Debug.Log("🏆 Registro agregado al ranking: " + registro);
    }
}
