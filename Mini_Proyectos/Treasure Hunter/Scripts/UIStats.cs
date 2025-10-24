using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIStats : MonoBehaviour
{
    [Header("Textos de UI")]
    public TextMeshProUGUI vidasText;
    public TextMeshProUGUI energiaText;
    public TextMeshProUGUI vidasRestantesText;

    [Header("Paneles")]
    public GameObject gameOverPanel;
    public GameObject vidaPerdidaPanel;
    public float duracionVidaPerdida = 2f;

    private JugadorStats jugador;

    public void SetJugador(JugadorStats nuevoJugador)
    {
        if (jugador != null)
        {
            JugadorStats.OnStatsChanged -= UpdateUI;
            JugadorStats.OnGameOver -= MostrarPantallaMuerte;
            JugadorStats.OnVidaPerdida -= MostrarVidaPerdida;
        }

        jugador = nuevoJugador;

        if (jugador != null)
        {
            JugadorStats.OnStatsChanged += UpdateUI;
            JugadorStats.OnGameOver += MostrarPantallaMuerte;
            JugadorStats.OnVidaPerdida += MostrarVidaPerdida;
        }

        UpdateUI(jugador != null ? jugador.vidas : 0, jugador != null ? jugador.energia : 0);
    }

    private void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (vidaPerdidaPanel != null) vidaPerdidaPanel.SetActive(false);
    }

    private void UpdateUI(int nuevasVidas, int nuevaEnergia)
    {
        if (vidasText != null) vidasText.text = "Vidas: " + nuevasVidas;
        if (energiaText != null) energiaText.text = "Energía: " + nuevaEnergia;
    }

    private void MostrarPantallaMuerte()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    private void MostrarVidaPerdida()
    {
        if (vidaPerdidaPanel != null)
        {
            vidaPerdidaPanel.SetActive(true);
            if (vidasRestantesText != null && jugador != null)
            {
                vidasRestantesText.text = "Vidas restantes: " + jugador.vidas;
            }
        }
    }

    public void Click_ReiniciarVidaPerdida()
    {
        Time.timeScale = 1f;

        if (jugador != null)
            jugador.RestaurarEnergia();

        Movimiento movimiento = FindObjectOfType<Movimiento>();
        if (movimiento != null)
            movimiento.RespawnJugador();

        if (vidaPerdidaPanel != null)
            vidaPerdidaPanel.SetActive(false);
    }

    public void Click_ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Click_IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
