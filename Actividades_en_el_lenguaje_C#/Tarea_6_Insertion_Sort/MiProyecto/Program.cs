using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 10;
        int[] numeros = new int[n];

        // Llenar con números aleatorios del 1 al 100
        for (int i = 0; i < n; i++)
        {
            numeros[i] = rand.Next(1, 101);
        }

        Console.WriteLine("Antes: " + string.Join(", ", numeros));

        // Insertion Sort
        for (int i = 1; i < n; i++)
        {
            int clave = numeros[i];
            int j = i - 1;

            // Mover elementos mayores que la clave una posición adelante
            while (j >= 0 && numeros[j] > clave)
            {
                numeros[j + 1] = numeros[j];
                j--;
            }
            numeros[j + 1] = clave;
        }

        Console.WriteLine("Después: " + string.Join(", ", numeros));
    }
}
