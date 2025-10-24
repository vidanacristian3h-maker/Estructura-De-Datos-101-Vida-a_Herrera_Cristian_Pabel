using UnityEngine;
using System;

public class JugadorStats : MonoBehaviour
{

    public static event Action<int, int> OnStatsChanged;
    public static event Action OnGameOver;
    public static event Action OnVidaPerdida;

    [SerializeField] private int maxVidas = 3;
    [SerializeField] private int maxEnergia = 4;
    public int puntuacionTotal = 0;


    private int _vidas;
    public int vidas
    {
        get { return _vidas; }
        private set
        {
            _vidas = Mathf.Max(0, value);
            ActualizarUI();
        }
    }

    private int _energia;
    public int energia
    {
        get { return _energia; }
        private set
        {
            _energia = Mathf.Clamp(value, 0, maxEnergia);
            ActualizarUI();

            if (_energia == 0)
            {
                PerderVida();
                if (vidas > 0)
                    _energia = maxEnergia;
            }
        }
    }

    private int pasosSinChocar = 0;
    private Movimiento movimiento;

    void Start()
    {
        // Si GameData existe, recupera la puntuación total acumulada
        if (GameData.instancia != null)
            puntuacionTotal = GameData.instancia.puntuacionJugador;

        _vidas = maxVidas;
        _energia = maxEnergia;
        movimiento = GetComponent<Movimiento>();
        ActualizarUI();
    }


    private void ActualizarUI()
    {
        OnStatsChanged?.Invoke(vidas, energia);
    }

    public void PerderEnergiaPorChoque()
    {
        energia -= 1;
        pasosSinChocar = 0;
        Debug.Log("⚠️ Choque! Energía restante: " + energia);
    }

    public void SumarPasoSinChocar()
    {
        pasosSinChocar++;
        if (pasosSinChocar >= 3)
        {
            pasosSinChocar = 0;
            if (energia < maxEnergia)
            {
                energia++;
                Debug.Log("💡 Energía recuperada: " + energia);
            }
        }
    }

    public void RecibirDañoDeTrampa()
    {
        // Simplemente llamamos a la lógica central de pérdida de vida/Game Over.
        PerderVida();
    }

    private void PerderVida()
    {
        vidas--;
        Debug.Log("💀 Vida perdida! Vidas restantes: " + vidas);

        if (vidas > 0)
        {
            OnVidaPerdida?.Invoke();
            Time.timeScale = 0f;

            // Generar nuevo mapa
            GeneradorMapa generador = FindFirstObjectByType<GeneradorMapa>();
            if (generador != null)
                generador.GenerarMapa();

            if (movimiento != null)
                movimiento.RespawnJugador();

            energia = maxEnergia;
        }
        else
        {
            Debug.Log("☠️ Game Over");

            // 🔹 Reiniciar puntuación
            puntuacionTotal = 0;
            if (GameData.instancia != null)
                GameData.instancia.puntuacionJugador = 0;

            if (movimiento != null)
                movimiento.enabled = false;

            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }



    public void RestaurarEnergia()
    {
        _energia = maxEnergia;
        ActualizarUI();
    }

    public void SetVidas(int nuevasVidas)
    {
        // Usa la lógica interna para respetar límites y actualizar UI
        _vidas = Mathf.Max(0, nuevasVidas);
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntuacionTotal += cantidad;

        // También actualizamos GameData para persistencia
        if (GameData.instancia != null)
            GameData.instancia.puntuacionJugador = puntuacionTotal;

        Debug.Log("💰 Puntos actuales: " + puntuacionTotal);
    }

}
