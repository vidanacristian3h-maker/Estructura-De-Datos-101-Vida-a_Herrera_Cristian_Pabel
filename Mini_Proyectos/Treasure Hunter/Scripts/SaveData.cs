using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int nivelActual;
    public int puntuacionTotal;
    public int vidasRestantes;
    public float tiempoTotal;

    public List<string> nombresItems = new List<string>();
    public List<int> valoresItems = new List<int>();
}
