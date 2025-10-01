using System;

class Program {
    // Mezclar dos mitades ordenadas
    static void Merge(int[] arr, int inicio, int medio, int fin) {
        int n1 = medio - inicio + 1;
        int n2 = fin - medio;

        int[] izquierda = new int[n1];
        int[] derecha = new int[n2];

        for (int i = 0; i < n1; i++) izquierda[i] = arr[inicio + i];
        for (int j = 0; j < n2; j++) derecha[j] = arr[medio + 1 + j];

        int k = inicio, x = 0, y = 0;

        while (x < n1 && y < n2) {
            if (izquierda[x] <= derecha[y]) arr[k++] = izquierda[x++];
            else arr[k++] = derecha[y++];
        }

        while (x < n1) arr[k++] = izquierda[x++];
        while (y < n2) arr[k++] = derecha[y++];
    }

    // MergeSort recursivo
    static void MergeSort(int[] arr, int inicio, int fin) {
        if (inicio < fin) {
            int medio = (inicio + fin) / 2;
            MergeSort(arr, inicio, medio);
            MergeSort(arr, medio + 1, fin);
            Merge(arr, inicio, medio, fin);
        }
    }

    static void Main() {
        Random rnd = new Random();
        int n = 15;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++) arr[i] = rnd.Next(100);

        Console.Write("Antes: ");
        foreach (int num in arr) Console.Write(num + " ");
        Console.WriteLine();

        MergeSort(arr, 0, arr.Length - 1);

        Console.Write("Despues: ");
        foreach (int num in arr) Console.Write(num + " ");
    }
}
