using System; // Para operaciones de entrada/salida (Console)

// Tamaño máximo de la pila
#define MAX_SIZE 100

class PilaArreglo
{
    int[] stack = new int[MAX_SIZE]; // Arreglo para almacenar los elementos de la pila
    int top = -1; // Índice del elemento superior de la pila

    // Función para agregar un elemento a la pila
    public void Push(int item)
    {
        if (top == MAX_SIZE - 1) // Verifica si la pila está llena
        {
            Console.WriteLine("Stack Overflow"); // Mensaje de error
            return; // Sale de la función
        }

        stack[++top] = item; // Incrementa el índice y agrega el elemento
    }

    // Función para eliminar y retornar el elemento superior de la pila
    public int Pop()
    {
        if (top == -1) // Verifica si la pila está vacía
        {
            Console.WriteLine("Stack Underflow"); // Mensaje de error
            return -1; // Retorna -1 para indicar que la pila está vacía
        }

        return stack[top--]; // Retorna el elemento superior y decrementa el índice
    }

    // Función para ver el elemento superior sin eliminarlo
    public int Peek()
    {
        if (top == -1) // Verifica si la pila está vacía
        {
            Console.WriteLine("Pila vacía"); // Mensaje de error
            return -1; // Retorna -1 para indicar que la pila está vacía
        }

        return stack[top]; // Retorna el elemento superior sin modificar el índice
    }

    // Función para verificar si la pila está vacía
    public bool IsEmpty() // Verifica si el índice superior es -1
    {
        return top == -1; // Retorna true si está vacía, false en caso contrario
    }

    // Función para verificar si la pila está llena
    public bool IsFull() // Verifica si el índice superior es igual al tamaño máximo menos uno
    {
        return top == MAX_SIZE - 1; // Retorna true si está llena, false en caso contrario
    }
}

class Program
{
    static void Main(string[] args)
    {
        PilaArreglo pila = new PilaArreglo();

        pila.Push(10); // Agrega elementos a la pila
        pila.Push(20); // agrega otro elemento
        pila.Push(30); // agrega otro elemento

        Console.WriteLine("Elemento Superior: " + pila.Peek()); // Muestra el elemento superior
        Console.WriteLine("Extrae elemento: " + pila.Pop()); // Elimina y muestra el elemento superior
        Console.WriteLine("Elemento Superior: " + pila.Peek()); // Muestra el nuevo elemento superior
    }
}
