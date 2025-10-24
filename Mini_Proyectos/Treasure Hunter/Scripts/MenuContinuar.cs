using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContinuar : MonoBehaviour
{
    public void ContinuarPartida()
    {
        SaveData data = SaveSystem.Cargar();

        if (data == null)
        {
            Debug.Log("🔄 No hay partida guardada, cargando nivel 1");
            SceneManager.LoadScene(1); // Primer nivel
            return;
        }

        // Asegurar GameData
        if (GameData.instancia == null)
        {
            GameObject go = new GameObject("GameData");
            go.AddComponent<GameData>();
        }

        GameData.instancia.nivelActualJugador = data.nivelActual;
        GameData.instancia.puntuacionJugador = data.puntuacionTotal;
        GameData.instancia.vidasJugador = data.vidasRestantes;

        int nivelCargar = Mathf.Clamp(data.nivelActual, 1, SceneManager.sceneCountInBuildSettings - 2);
        Debug.Log($"🔄 Continuando partida desde el nivel {nivelCargar}");
        SceneManager.LoadScene(nivelCargar);
    }

    public void NuevaPartida()
    {
        SaveSystem.Borrar();

        // Reiniciar GameData
        if (GameData.instancia != null)
            GameData.instancia.ReiniciarDatos();

        SceneManager.LoadScene(1); // Primer nivel
    }
}
