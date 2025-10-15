using System;
using System.Collections.Generic;

class Program
{
    static void BucketSort(float[] arr)
    {
        int n = arr.Length;
        if (n <= 0) return;

        // Crear "cubetas" (listas) vacías
        List<float>[] buckets = new List<float>[n];
        for (int i = 0; i < n; i++)
            buckets[i] = new List<float>();

        // Colocar cada número en su cubeta correspondiente
        foreach (float num in arr)
        {
            int index = (int)(num * n); // posición según valor
            buckets[index].Add(num);
        }

        // Ordenar cada cubeta individualmente
        for (int i = 0; i < n; i++)
            buckets[i].Sort();

        // Unir todas las cubetas en el arreglo final
        int k = 0;
        for (int i = 0; i < n; i++)
            foreach (float num in buckets[i])
                arr[k++] = num;
    }

    static void Main()
    {
        Random rand = new Random();
        float[] arr = new float[10];

        // Generar números aleatorios entre 0 y 1
        for (int i = 0; i < arr.Length; i++)
            arr[i] = (float)rand.NextDouble();

        Console.WriteLine("Antes:");
        foreach (float x in arr) Console.Write(x + " ");

        BucketSort(arr);

        Console.WriteLine("\n\nDespués:");
        foreach (float x in arr) Console.Write(x + " ");
    }
}
