import java.util.Random;

public class program {
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

        // Bubble Sort
        boolean swapped;
        do {
            swapped = false;
            for (int i = 0; i < numeros.length - 1; i++) {
                if (numeros[i] > numeros[i + 1]) {
                    int temp = numeros[i];
                    numeros[i] = numeros[i + 1];
                    numeros[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);

        System.out.print("Después: ");
        for (int num : numeros) System.out.print(num + " ");
    }
}
