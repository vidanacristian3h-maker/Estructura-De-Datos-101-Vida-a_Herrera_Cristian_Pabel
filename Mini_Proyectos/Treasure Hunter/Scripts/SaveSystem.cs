using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string rutaArchivo = Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void Guardar(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(rutaArchivo, json);
    }

    public static SaveData Cargar()
    {
        if (!File.Exists(rutaArchivo)) return null;
        string json = File.ReadAllText(rutaArchivo);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void Borrar()
    {
        if (File.Exists(rutaArchivo))
            File.Delete(rutaArchivo);
    }
}
