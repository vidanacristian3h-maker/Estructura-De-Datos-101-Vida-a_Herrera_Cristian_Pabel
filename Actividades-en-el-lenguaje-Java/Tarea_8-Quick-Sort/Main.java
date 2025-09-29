import java.util.Random;

public class Main {
    // Función QuickSort
    static void quickSort(int[] arr, int inicio, int fin) {
        int i = inicio, j = fin;
        int pivote = arr[(inicio + fin) / 2]; // Pivote central

        while (i <= j) {
            while (arr[i] < pivote) i++; // mover izquierda
            while (arr[j] > pivote) j--; // mover derecha

            if (i <= j) {
                // Intercambio
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++; j--;
            }
        }

        // Llamadas recursivas
        if (inicio < j) quickSort(arr, inicio, j);
        if (i < fin) quickSort(arr, i, fin);
    }

    public static void main(String[] args) {
        Random rnd = new Random();
        int n = 15;
        int[] arr = new int[n];

        // Generar aleatorios
        for (int i = 0; i < n; i++) arr[i] = rnd.nextInt(100);

        System.out.print("Antes: ");
        for (int num : arr) System.out.print(num + " ");
        System.out.println();

        // Ordenar
        quickSort(arr, 0, arr.length - 1);

        System.out.print("Despues: ");
        for (int num : arr) System.out.print(num + " ");
    }
}
