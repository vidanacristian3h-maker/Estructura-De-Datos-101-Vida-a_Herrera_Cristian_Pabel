import java.util.Random;

public class main {
    static int obtenerMax(int[] arr) {
        int max = arr[0];
        for (int num : arr)
            if (num > max) max = num;
        return max;
    }

    static void contarOrden(int[] arr, int exp) {
        int n = arr.length;
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

    static void radixSort(int[] arr) {
        int max = obtenerMax(arr);
        for (int exp = 1; max / exp > 0; exp *= 10)
            contarOrden(arr, exp);
    }

    public static void main(String[] args) {
        Random rnd = new Random();
        int[] arr = new int[15];
        for (int i = 0; i < arr.length; i++)
            arr[i] = rnd.nextInt(1000);

        System.out.print("Antes: ");
        for (int n : arr) System.out.print(n + " ");
        System.out.println();

        radixSort(arr);

        System.out.print("Despues: ");
        for (int n : arr) System.out.print(n + " ");
    }
}
