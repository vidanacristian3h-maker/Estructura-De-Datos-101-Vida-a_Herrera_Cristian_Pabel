using System;

class Program {
    // Función QuickSort
    static void QuickSort(int[] arr, int inicio, int fin) {
        int i = inicio, j = fin;
        int pivote = arr[(inicio + fin) / 2]; // Pivote en el centro

        // Reordenar
        while (i <= j) {
            while (arr[i] < pivote) i++; // avanzar izquierda
            while (arr[j] > pivote) j--; // retroceder derecha

            if (i <= j) {
                // intercambiar
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++; j--;
            }
        }

        // Recursión
        if (inicio < j) QuickSort(arr, inicio, j);
        if (i < fin) QuickSort(arr, i, fin);
    }

    static void Main() {
        Random rnd = new Random();
        int n = 15;
        int[] arr = new int[n];

        // Generar aleatorios
        for (int i = 0; i < n; i++) arr[i] = rnd.Next(100);

        Console.Write("Antes: ");
        foreach (int num in arr) Console.Write(num + " ");
        Console.WriteLine();

        // Ordenar
        QuickSort(arr, 0, arr.Length - 1);

        Console.Write("Despues: ");
        foreach (int num in arr) Console.Write(num + " ");
    }
}
