using System;

class Nodo {
    public int dato;
    public Nodo siguiente;
}

class Program {
    static Nodo front = null;
    static Nodo rear = null;

    static void Insertar() {
        Console.Write("\nIngrese el elemento: ");
        int elemento = int.Parse(Console.ReadLine());

        Nodo nuevo = new Nodo();
        nuevo.dato = elemento;
        nuevo.siguiente = null;

        if (front == null && rear == null) {
            front = rear = nuevo;
        } else {
            rear.siguiente = nuevo;
            rear = nuevo;
        }

        Console.WriteLine("\nElemento insertado correctamente.");
    }

    static void Eliminar() {
        if (front == null) {
            Console.WriteLine("\nSUBDESBORDAMIENTO (UNDERFLOW)");
            return;
        }

        int elemento = front.dato;

        if (front == rear) {
            front = rear = null;
        } else {
            front = front.siguiente;
        }

        Console.WriteLine($"\nElemento eliminado: {elemento}");
    }

    static void Mostrar() {
        if (front == null) {
            Console.WriteLine("\nLa cola está vacía.");
            return;
        }

        Console.WriteLine("\nElementos en la cola:");
        Nodo temp = front;
        while (temp != null) {
            Console.WriteLine(temp.dato);
            temp = temp.siguiente;
        }
    }

    static void Main() {
        int opcion = 0;

        while (opcion != 4) {
            Console.WriteLine("\n*************** MENU PRINCIPAL ***************");
            Console.WriteLine("1. Insertar un elemento");
            Console.WriteLine("2. Eliminar un elemento");
            Console.WriteLine("3. Mostrar la cola");
            Console.WriteLine("4. Salir");
            Console.Write("Ingrese su opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1: Insertar(); break;
                case 2: Eliminar(); break;
                case 3: Mostrar(); break;
                case 4: Console.WriteLine("\nSaliendo del programa..."); break;
                default: Console.WriteLine("\nOpción inválida."); break;
            }
        }
    }
}
