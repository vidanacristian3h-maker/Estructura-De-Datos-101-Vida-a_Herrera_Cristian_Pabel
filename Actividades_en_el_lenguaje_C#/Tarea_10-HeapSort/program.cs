using System;

class HeapSortRandom {
    // Método principal del ordenamiento
    static void HeapSort(int[] arr) {
        int n = arr.Length;

        // 1️⃣ Construir un heap (montículo máximo)
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // 2️⃣ Extraer los elementos uno por uno del heap
        for (int i = n - 1; i > 0; i--) {
            // Mover la raíz (mayor elemento) al final
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Llamar a heapify en el heap reducido
            Heapify(arr, i, 0);
        }
    }

    // Reorganiza el heap para mantener la propiedad del montículo
    static void Heapify(int[] arr, int n, int i) {
        int mayor = i;       // Se asume que la raíz es la mayor
        int izq = 2 * i + 1; // Hijo izquierdo
        int der = 2 * i + 2; // Hijo derecho

        // Si el hijo izquierdo es mayor que la raíz
        if (izq < n && arr[izq] > arr[mayor])
            mayor = izq;

        // Si el hijo derecho es mayor que el mayor actual
        if (der < n && arr[der] > arr[mayor])
            mayor = der;

        // Si el mayor no es la raíz, intercambiar y seguir ajustando
        if (mayor != i) {
            int temp = arr[i];
            arr[i] = arr[mayor];
            arr[mayor] = temp;
            Heapify(arr, n, mayor);
        }
    }

    static void Main() {
        Random rnd = new Random();
        int n = 10;
        int[] arr = new int[n];

        // Generar números aleatorios entre 1 y 99
        for (int i = 0; i < n; i++)
            arr[i] = rnd.Next(1, 100);

        Console.WriteLine("Arreglo original: " + string.Join(", ", arr));
        HeapSort(arr);
        Console.WriteLine("Arreglo ordenado: " + string.Join(", ", arr));
    }
}
