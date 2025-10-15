import java.util.Random;

public class main {

    // Método principal del ordenamiento
    public static void heapSort(int arr[]) {
        int n = arr.length;

        // 1️⃣ Construir un heap máximo
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);

        // 2️⃣ Extraer los elementos del heap
        for (int i = n - 1; i > 0; i--) {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            heapify(arr, i, 0);
        }
    }

    // Ajusta el heap
    static void heapify(int arr[], int n, int i) {
        int mayor = i;       // Suponemos que el nodo actual es el mayor
        int izq = 2 * i + 1; // Hijo izquierdo
        int der = 2 * i + 2; // Hijo derecho

        if (izq < n && arr[izq] > arr[mayor])
            mayor = izq;
        if (der < n && arr[der] > arr[mayor])
            mayor = der;

        // Si el mayor no es la raíz, intercambiar y continuar
        if (mayor != i) {
            int temp = arr[i];
            arr[i] = arr[mayor];
            arr[mayor] = temp;
            heapify(arr, n, mayor);
        }
    }

    public static void main(String[] args) {
        Random rnd = new Random();
        int n = 10;
        int[] arr = new int[n];

        // Generar números aleatorios
        for (int i = 0; i < n; i++)
            arr[i] = rnd.nextInt(100) + 1;

        System.out.println("Arreglo original:");
        for (int num : arr) System.out.print(num + " ");
        System.out.println();

        heapSort(arr);

        System.out.println("Arreglo ordenado:");
        for (int num : arr) System.out.print(num + " ");
    }
}
