import java.util.Random;

public class main {
    public static void main(String[] args) {
        int n = 10;
        int[] numeros = new int[n];
        Random rand = new Random();

        for (int i = 0; i < n; i++) {
            numeros[i] = rand.nextInt(100) + 1;
        }

        System.out.print("Antes: ");
        for (int num : numeros) System.out.print(num + " ");
        System.out.println();

        // Insertion Sort
        for (int i = 1; i < n; i++) {
            int clave = numeros[i];
            int j = i - 1;

            while (j >= 0 && numeros[j] > clave) {
                numeros[j + 1] = numeros[j];
                j--;
            }
            numeros[j + 1] = clave;
        }

        System.out.print("Después: ");
        for (int num : numeros) System.out.print(num + " ");
    }
}
