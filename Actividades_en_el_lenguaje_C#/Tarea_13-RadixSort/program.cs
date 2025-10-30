using System;

class Program {
    static int ObtenerMax(int[] arr) {
        int max = arr[0];
        foreach (int num in arr)
            if (num > max) max = num;
        return max;
    }

    static void ContarOrden(int[] arr, int exp) {
        int n = arr.Length;
        int[] salida = new int[n];
        int[] conteo = new int[10];

        for (int i = 0; i < n; i++)
            conteo[(arr[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            conteo[i] += conteo[i - 1];

        for (int i = n - 1; i >= 0; i--) {
            salida[conteo[(arr[i] / exp) % 10] - 1] = arr[i];
            conteo[(arr[i] / exp) % 10]--;
        }

        for (int i = 0; i < n; i++)
            arr[i] = salida[i];
    }

    static void RadixSort(int[] arr) {
        int max = ObtenerMax(arr);
        for (int exp = 1; max / exp > 0; exp *= 10)
            ContarOrden(arr, exp);
    }

    static void Main() {
        Random rnd = new Random();
        int[] arr = new int[15];
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rnd.Next(1000);

        Console.WriteLine("Antes: " + string.Join(" ", arr));
        RadixSort(arr);
        Console.WriteLine("Despues: " + string.Join(" ", arr));
    }
}
