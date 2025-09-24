using System;

class Program {
    static void Main() {
        const int n = 10;
        int[] numeros = new int[n];
        Random rnd = new Random();

        // Generar números aleatorios entre 1 y 100
        for (int i = 0; i < n; i++) {
            numeros[i] = rnd.Next(1, 101);
        }

        Console.WriteLine("Antes: " + string.Join(" ", numeros));

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

        Console.WriteLine("Después: " + string.Join(" ", numeros));
    }
}
