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

        // Bubble Sort
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                if (numeros[i] > numeros[i + 1])
                {
                    int temp = numeros[i];
                    numeros[i] = numeros[i + 1];
                    numeros[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);

        Console.WriteLine("Después: " + string.Join(", ", numeros));
    }
}

