import java.util.Random;

public class Main {
    public static void main(String[] args) {
        int n = 10;
        int[] numeros = new int[n];
        Random rnd = new Random();

        // Generar números aleatorios entre 1 y 100
        for (int i = 0; i < n; i++) {
            numeros[i] = rnd.nextInt(100) + 1;
        }

        System.out.print("Antes: ");
        for (int num : numeros) System.out.print(num + " ");
        System.out.println();

        // ---------- Selection Sort ----------
        for (int i = 0; i < n - 1; i++) {
            int posicionMenor = i;
            for (int j = i + 1; j < n; j++) {
                if (numeros[j] < numeros[posicionMenor]) {
                    posicionMenor = j;
                }
            }
            // Intercambiar
            int temp = numeros[i];
            numeros[i] = numeros[posicionMenor];
            numeros[posicionMenor] = temp;
        }

        System.out.print("Después: ");
        for (int num : numeros) System.out.print(num + " ");
    }
}
