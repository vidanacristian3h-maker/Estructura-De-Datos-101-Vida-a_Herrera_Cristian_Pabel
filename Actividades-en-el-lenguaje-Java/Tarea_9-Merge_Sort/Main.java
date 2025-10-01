import java.util.Random;

public class Main {
    // Mezclar dos mitades ordenadas
    static void merge(int[] arr, int inicio, int medio, int fin) {
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
    static void mergeSort(int[] arr, int inicio, int fin) {
        if (inicio < fin) {
            int medio = (inicio + fin) / 2;
            mergeSort(arr, inicio, medio);
            mergeSort(arr, medio + 1, fin);
            merge(arr, inicio, medio, fin);
        }
    }

    public static void main(String[] args) {
        Random rnd = new Random();
        int n = 15;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++) arr[i] = rnd.nextInt(100);

        System.out.print("Antes: ");
        for (int num : arr) System.out.print(num + " ");
        System.out.println();

        mergeSort(arr, 0, arr.length - 1);

        System.out.print("Despues: ");
        for (int num : arr) System.out.print(num + " ");
    }
}
