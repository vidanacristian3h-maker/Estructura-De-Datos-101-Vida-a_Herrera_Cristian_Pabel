using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class RegistroJugador
{
    public string nombre;
    public int nivelAlcanzado;
    public int puntosTotales;

    public RegistroJugador(string nombre, int nivelAlcanzado, int puntosTotales)
    {
        this.nombre = nombre;
        this.nivelAlcanzado = nivelAlcanzado;
        this.puntosTotales = puntosTotales;
    }

    public override string ToString()
    {
        string nivelTexto = nivelAlcanzado >= 3 ? "Juego Completado" : "Nivel " + nivelAlcanzado;
        return $"{nombre} | {nivelTexto} | {puntosTotales} pts";
    }
}

public class Ranking : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelRanking;
    public TextMeshProUGUI textoRanking;

    [Header("Botones del menú")]
    public Button Btn_NewGame;
    public Button Btn_AbrirRanking;
    public Button Btn_Salir;
    public Button Btn_ContinueGame;

    private static string rutaArchivo;

    private void Awake()
    {
        rutaArchivo = Path.Combine(Application.persistentDataPath, "ranking.txt");
    }

    public void MostrarRanking()
    {
        // Desactivar botones del menú
        if (Btn_NewGame != null) Btn_NewGame.interactable = false;
        if (Btn_AbrirRanking != null) Btn_AbrirRanking.interactable = false;
        if (Btn_Salir != null) Btn_Salir.interactable = false;
        if (Btn_ContinueGame != null) Btn_ContinueGame.interactable = false;

        if (panelRanking != null)
            panelRanking.SetActive(true);

        if (textoRanking != null)
        {
            textoRanking.text = "🏆 Ranking de Jugadores 🏆\n\n";

            List<RegistroJugador> lista = LeerRanking();
            if (lista.Count == 0)
                textoRanking.text += "No hay registros aún.";
            else
            {
                int posicion = 1;
                foreach (var r in lista)
                {
                    textoRanking.text += $"{posicion}. {r}\n";
                    posicion++;
                }
            }
        }
    }

    public void CerrarRanking()
    {
        if (panelRanking != null)
            panelRanking.SetActive(false);

        // Reactivar botones del menú
        if (Btn_NewGame != null) Btn_NewGame.interactable = true;
        if (Btn_AbrirRanking != null) Btn_AbrirRanking.interactable = true;
        if (Btn_Salir != null) Btn_Salir.interactable = true;
        if (Btn_ContinueGame != null) Btn_ContinueGame.interactable = true;
    }

    public static void AgregarRegistro(RegistroJugador registro)
    {
        if (string.IsNullOrEmpty(rutaArchivo))
            rutaArchivo = Path.Combine(Application.persistentDataPath, "ranking.txt");

        string linea = $"{registro.nombre},{registro.nivelAlcanzado},{registro.puntosTotales}";
        File.AppendAllText(rutaArchivo, linea + "\n");
    }

    public static List<RegistroJugador> LeerRanking()
    {
        List<RegistroJugador> lista = new List<RegistroJugador>();

        if (string.IsNullOrEmpty(rutaArchivo))
            rutaArchivo = Path.Combine(Application.persistentDataPath, "ranking.txt");

        if (!File.Exists(rutaArchivo))
            return lista;

        string[] lineas = File.ReadAllLines(rutaArchivo);
        foreach (string linea in lineas)
        {
            string[] partes = linea.Split(',');
            if (partes.Length == 3)
            {
                string nombre = partes[0];
                if (!int.TryParse(partes[1], out int nivel)) nivel = 0;
                if (!int.TryParse(partes[2], out int puntos)) puntos = 0;
                lista.Add(new RegistroJugador(nombre, nivel, puntos));
            }
        }

        lista.Sort((a, b) => b.puntosTotales.CompareTo(a.puntosTotales));
        return lista;
    }
}
