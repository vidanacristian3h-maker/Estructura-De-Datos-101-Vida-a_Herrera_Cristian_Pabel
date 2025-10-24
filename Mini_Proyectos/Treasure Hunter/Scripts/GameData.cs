using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instancia;

    [HideInInspector] public List<Inventario.Item> itemsJugador = new List<Inventario.Item>();
    [HideInInspector] public int puntuacionJugador = 0;
    [HideInInspector] public int vidasJugador = 3;
    [HideInInspector] public int nivelActualJugador = 1;

    void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ReiniciarDatos()
    {
        itemsJugador.Clear();
        puntuacionJugador = 0;
        vidasJugador = 3;
        nivelActualJugador = 1;
    }
}
