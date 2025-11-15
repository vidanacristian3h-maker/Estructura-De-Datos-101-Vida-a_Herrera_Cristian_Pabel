using System;
using System.Text;

// --- CLASE 1: Node ---
// El "eslabón" de la lista.
// Contiene el dato y los punteros al nodo siguiente y al anterior.
public class Node<T>
{
    public T data;
    public Node<T> next;
    public Node<T> prev; // Puntero al nodo anterior

    public Node(T val)
    {
        data = val;
        next = null;
        prev = null;
    }
}

// --- CLASE 2: CircularDoublyLinkedList ---
public class CircularDoublyLinkedList<T>
{
    private Node<T> head; // Solo necesitamos el puntero al inicio

    public CircularDoublyLinkedList()
    {
        head = null;
    }

    // --- Método para verificar si está vacía ---
    public bool IsEmpty()
    {
        return head == null;
    }

    // --- Método para agregar un nodo al final ---
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (IsEmpty())
        {
            // Caso 1: La lista está vacía
            head = newNode;
            head.next = head; // Apunta a sí mismo
            head.prev = head; // Apunta a sí mismo
        }
        else
        {
            // Caso 2: La lista NO está vacía
            // 1. Encontrar el último nodo (que es head.prev)
            Node<T> tail = head.prev;

            // 2. Conectar el nuevo nodo
            newNode.next = head;  // El siguiente del nuevo es la cabeza
            newNode.prev = tail;  // El anterior del nuevo es la (vieja) cola

            // 3. Actualizar los punteros de la cabeza y la (vieja) cola
            head.prev = newNode;  // El anterior de la cabeza es el nuevo nodo
            tail.next = newNode;  // El siguiente de la (vieja) cola es el nuevo nodo
        }
    }

    // --- Método para eliminar un nodo por valor ---
    public bool Delete(T data)
    {
        if (IsEmpty())
        {
            // No se puede borrar de una lista vacía
            return false;
        }

        Node<T> current = head;
        bool found = false;

        // Bucle do-while para recorrer la lista circular
        do
        {
            // Usamos .Equals() para comparar strings u objetos
            if (current.data.Equals(data))
            {
                found = true;
                break;
            }
            current = current.next;
        } while (current != head);

        if (!found)
        {
            // No se encontró el dato
            return false;
        }

        // --- El nodo SÍ se encontró ---

        // Caso 1: Es el único nodo en la lista
        if (current.next == head && current.prev == head)
        {
            head = null;
            return true;
        }

        // Caso 2: Es un nodo intermedio (o cabeza/cola en lista > 1)
        // Conectamos su nodo anterior con su nodo siguiente
        current.prev.next = current.next;
        current.next.prev = current.prev;

        // Caso 3: Si el nodo a borrar era la CABEZA (head)
        if (current == head)
        {
            head = current.next; 
        }

        return true;
    }

    // mostrar la lista hacia adelante 
    public string DisplayForward()
    {
        if (IsEmpty())
        {
            return "Lista vacía";
        }

        StringBuilder sb = new StringBuilder();
        Node<T> current = head;

        sb.Append("head -> ");
        do
        {
            sb.Append($"[{current.data}] <-> ");
            current = current.next;
        } while (current != head); 

        sb.Append("... (vuelve a head)");
        return sb.ToString();
    }

    // mostrar la lista hacia atrás 
    public string DisplayReverse()
    {
        if (IsEmpty())
        {
            return "Lista vacía";
        }

        StringBuilder sb = new StringBuilder();
        // Empezamos por el final 
        Node<T> current = head.prev; 

        sb.Append("tail -> ");
        do
        {
            sb.Append($"[{current.data}] <-> ");
            current = current.prev;
        } while (current != head.prev);

        sb.Append("... (vuelve a tail)");
        return sb.ToString();
    }
}


public class Program
{
    // Función de ayuda para mostrar siempre el estado actual de la lista
    private static void ShowCurrentList(CircularDoublyLinkedList<string> list)
    {
        Console.WriteLine("\n--- ESTADO ACTUAL DE LA LISTA ---");
        
        // Mostrar hacia adelante en color Cian
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Adelante: " + list.DisplayForward());
        
        // Mostrar hacia atrás en color Amarillo
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Atrás:    " + list.DisplayReverse());
        
        // Resetear color
        Console.ResetColor();
        Console.WriteLine("---------------------------------");
    }

    public static void Main(string[] args)
    {
        CircularDoublyLinkedList<string> list = new CircularDoublyLinkedList<string>();
        bool running = true;

        Console.WriteLine("--- Probador Interactivo de Lista Doble Circular ---");

        while (running)
        {
            // 1. Muestra el estado actual de la lista
            ShowCurrentList(list);

            // 2. Muestra el menú de opciones
            Console.WriteLine("\nElige una opcion:");
            Console.WriteLine("1. Agregar un valor (al final)");
            Console.WriteLine("2. Eliminar un valor");
            Console.WriteLine("3. Salir");
            Console.Write("Opcion: ");

            string choice = Console.ReadLine();
            string value;

            // 3. Actúa según la elección
            switch (choice)
            {
                case "1":
                    Console.Write("  -> Escribe el valor a AGREGAR: ");
                    value = Console.ReadLine();
                    list.Add(value);
                    Console.WriteLine($"'{value}' agregado.");
                    break;

                case "2":
                    Console.Write("  -> Escribe el valor a ELIMINAR: ");
                    value = Console.ReadLine();
                    if (list.Delete(value))
                    {
                        Console.WriteLine($"'{value}' eliminado.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"'{value}' NO se encontró en la lista.");
                        Console.ResetColor();
                    }
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("¡Adiós!");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}