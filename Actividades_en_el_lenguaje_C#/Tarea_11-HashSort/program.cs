using System;
using System.Collections.Generic;

class HashSort {
    static void Main() {
        Random rnd = new Random();
        int n = 10;
        int[] arr = new int[n];

        // Generar números aleatorios entre 0 y 50
        for (int i = 0; i < n; i++)
            arr[i] = rnd.Next(0, 51);

        Console.WriteLine("Arreglo original: " + string.Join(", ", arr));

        // Crear tabla hash (diccionario)
        Dictionary<int, int> hash = new Dictionary<int, int>();

        // Contar ocurrencias de cada número
        foreach (int num in arr) {
            if (hash.ContainsKey(num))
                hash[num]++;
            else
                hash[num] = 1;
        }

        // Reconstruir arreglo ordenado
        int index = 0;
        foreach (int key in new SortedSet<int>(hash.Keys)) {
            for (int j = 0; j < hash[key]; j++)
                arr[index++] = key;
        }

        Console.WriteLine("Arreglo ordenado: " + string.Join(", ", arr));
    }
}
