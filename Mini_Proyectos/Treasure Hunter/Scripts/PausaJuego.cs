using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaJuego : MonoBehaviour
{
    public GameObject menuPausa; // Panel del menú de pausa

    private bool juegoPausado = false;

    void Update()
    {
        // Abrir/cerrar menú de pausa con ESC o P
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        if (menuPausa != null)
            menuPausa.SetActive(true);

        Time.timeScale = 0f; // Detener el tiempo
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        if (menuPausa != null)
            menuPausa.SetActive(false);

        Time.timeScale = 1f; // Reanudar el tiempo
        juegoPausado = false;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // tu escena de menú principal
    }
}
