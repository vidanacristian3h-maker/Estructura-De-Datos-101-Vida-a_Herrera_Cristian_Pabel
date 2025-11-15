using System;

public class Node
{
    public int Data;  // Valor almacenado en el nodo
    public Node Next; // Puntero al siguiente nodo

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class CircularLinkedList
{
    // Puntero al primer nodo (head)
    private Node head = null;

    // --- Inserta un nodo al principio ---
    public void BeginInsert()
    {
        try
        {
            Console.Write("\nIngrese valor: ");
            int item = int.Parse(Console.ReadLine());
            Node ptr = new Node(item);

            if (head == null)
            {
                head = ptr;
                ptr.Next = head; // Apunta a sí mismo para mantener circularidad
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                ptr.Next = head;
                temp.Next = ptr;
                head = ptr;
            }
            Console.WriteLine("\nNodo insertado al principio.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Por favor, ingrese un número válido.");
        }
    }

    // --- Inserta un nodo al final ---
    public void LastInsert()
    {
        try
        {
            Console.Write("\nIngrese valor: ");
            int item = int.Parse(Console.ReadLine());
            Node ptr = new Node(item);

            if (head == null)
            {
                head = ptr;
                ptr.Next = head;
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = ptr;
                ptr.Next = head;
            }
            Console.WriteLine("\nNodo insertado al final.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Por favor, ingrese un número válido.");
        }
    }

    // --- Inserta un nodo después de una posición específica ---
    public void RandomInsert()
    {
        if (head == null)
        {
            Console.WriteLine("\nLa lista está vacía.");
            return;
        }

        try
        {
            Console.Write("\nIngrese valor: ");
            int item = int.Parse(Console.ReadLine());
            Console.Write("\nIntroduce la ubicación (índice 0) después de la cual deseas insertar: ");
            int loc = int.Parse(Console.ReadLine());

            Node ptr = new Node(item);
            Node temp = head;

            // Avanza 'loc' veces para encontrar el nodo en esa posición
            for (int i = 0; i < loc; i++)
            {
                temp = temp.Next;
                if (temp == head)
                {
                    Console.WriteLine("\nNo se puede insertar, posición fuera de rango.");
                    return;
                }
            }

            ptr.Next = temp.Next;
            temp.Next = ptr;
            Console.WriteLine("\nNodo insertado en la posición indicada.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Por favor, ingrese un número válido.");
        }
    }

    // --- Elimina el primer nodo ---
    public void BeginDelete()
    {
        if (head == null)
        {
            Console.WriteLine("\nLa lista está vacía.");
            return;
        }

        if (head.Next == head) // Solo hay un nodo
        {
            head = null;
        }
        else
        {
            Node last = head;
            while (last.Next != head)
            {
                last = last.Next;
            }
            head = head.Next;
            last.Next = head;
        }
        Console.WriteLine("\nNodo eliminado desde el principio.");
    }

    // --- Elimina el último nodo ---
    public void LastDelete()
    {
        if (head == null)
        {
            Console.WriteLine("\nLa lista está vacía.");
            return;
        }

        if (head.Next == head) // Solo hay un nodo
        {
            head = null;
        }
        else
        {
            Node temp = head;
            Node prev = null;
            while (temp.Next != head)
            {
                prev = temp;
                temp = temp.Next;
            }
            prev.Next = head; // El penúltimo ahora apunta al head
        }
        Console.WriteLine("\nNodo eliminado desde el final.");
    }

    // --- Elimina un nodo en una posición específica (índice 0) ---
    // (Lógica corregida del original en JS, que fallaba en el índice 0)
    public void RandomDelete()
    {
        if (head == null)
        {
            Console.WriteLine("\nLa lista está vacía.");
            return;
        }

        try
        {
            Console.Write("\nIntroduzca la ubicación (índice 0) del nodo a eliminar: ");
            int loc = int.Parse(Console.ReadLine());

            if (loc == 0)
            {
                // Si es el índice 0, es un caso especial
                BeginDelete(); // Reutilizamos la lógica de borrar el primero
                return;
            }
            
            Node temp = head;
            Node prev = null;

            // Avanza 'loc' veces para encontrar el nodo a eliminar
            for (int i = 0; i < loc; i++)
            {
                prev = temp;
                temp = temp.Next;
                if (temp == head)
                {
                    Console.WriteLine("\nNo se puede eliminar, posición fuera de rango.");
                    return;
                }
            }

            // 'temp' es el nodo a eliminar, 'prev' es el anterior
            prev.Next = temp.Next;
            Console.WriteLine("\nNodo eliminado correctamente.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Por favor, ingrese un número válido.");
        }
    }

    // --- Busca un elemento y muestra su posición ---
    public void Search()
    {
        if (head == null)
        {
            Console.WriteLine("\nLista vacía.");
            return;
        }

        try
        {
            Console.Write("\nIntroduce el elemento que deseas buscar: ");
            int item = int.Parse(Console.ReadLine());
            Node temp = head;
            int pos = 1; // 1-based index como en el JS
            bool found = false;

            do
            {
                if (temp.Data == item)
                {
                    Console.WriteLine($"Elemento encontrado en la ubicación {pos}");
                    found = true;
                }
                temp = temp.Next;
                pos++;
            } while (temp != head);

            if (!found)
            {
                Console.WriteLine("Elemento no encontrado.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Por favor, ingrese un número válido.");
        }
    }

    // --- Muestra todos los elementos de la lista ---
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("\nNada que imprimir.");
            return;
        }

        Console.WriteLine("\nImprimiendo valores...");
        Node temp = head;
        do
        {
            Console.WriteLine(temp.Data);
            temp = temp.Next;
        } while (temp != head);
    }
}

/// <summary>
/// Clase principal del programa que contiene el método Main (punto de entrada)
/// </summary>
public class Program
{
    // --- Menú principal (punto de entrada) ---
    public static void Main(string[] args)
    {
        CircularLinkedList list = new CircularLinkedList();
        int choice = 0;

        while (choice != 9)
        {
            Console.WriteLine("\n\n********Menú principal********");
            Console.WriteLine("1. Insertar al principio\t2. Insertar al final\t3. Insertar en una posición específica");
            Console.WriteLine("4. Eliminar del principio\t5. Eliminar desde el último\t6. Eliminar nodo después de la ubicación especificada");
            Console.WriteLine("7. Buscar un elemento\t\t8. Mostrar\t\t9. Salir");
            Console.Write("\nIngrese su opción:\t");

            try
            {
                // Intenta leer y parsear la opción del usuario
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        list.BeginInsert();
                        break;
                    case 2:
                        list.LastInsert();
                        break;
                    case 3:
                        list.RandomInsert();
                        break;
                    case 4:
                        list.BeginDelete();
                        break;
                    case 5:
                        list.LastDelete();
                        break;
                    case 6:
                        list.RandomDelete();
                        break;
                    case 7:
                        list.Search();
                        break;
                    case 8:
                        list.Display();
                        break;
                    case 9:
                        Console.WriteLine("Saliendo del programa...");
                        break; // Sale del bucle while
                    default:
                        Console.WriteLine("Introduzca una opción válida (1-9).");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Por favor, ingrese un número válido.");
            }
        }
    }
}