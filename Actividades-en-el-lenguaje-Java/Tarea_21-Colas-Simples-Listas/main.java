import java.util.Scanner;

class Nodo {
    int dato;
    Nodo siguiente;
}

public class main {
    static Nodo front = null;
    static Nodo rear = null;

    static Scanner sc = new Scanner(System.in);

    static void insertar() {
        System.out.print("\nIngrese el elemento: ");
        int elemento = sc.nextInt();

        Nodo nuevo = new Nodo();
        nuevo.dato = elemento;
        nuevo.siguiente = null;

        if (front == null && rear == null) {
            front = rear = nuevo;
        } else {
            rear.siguiente = nuevo;
            rear = nuevo;
        }

        System.out.println("\nElemento insertado correctamente.");
    }

    static void eliminar() {
        if (front == null) {
            System.out.println("\nSUBDESBORDAMIENTO (UNDERFLOW)");
            return;
        }

        int elemento = front.dato;

        if (front == rear) {
            front = rear = null;
        } else {
            front = front.siguiente;
        }

        System.out.println("\nElemento eliminado: " + elemento);
    }

    static void mostrar() {
        if (front == null) {
            System.out.println("\nLa cola está vacía.");
            return;
        }

        System.out.println("\nElementos en la cola:");
        Nodo temp = front;
        while (temp != null) {
            System.out.println(temp.dato);
            temp = temp.siguiente;
        }
    }

    public static void main(String[] args) {
        int opcion = 0;

        while (opcion != 4) {
            System.out.println("\n*************** MENU PRINCIPAL ***************");
            System.out.println("1. Insertar un elemento");
            System.out.println("2. Eliminar un elemento");
            System.out.println("3. Mostrar la cola");
            System.out.println("4. Salir");
            System.out.print("Ingrese su opción: ");
            opcion = sc.nextInt();

            switch (opcion) {
                case 1: insertar(); break;
                case 2: eliminar(); break;
                case 3: mostrar(); break;
                case 4: System.out.println("\nSaliendo del programa..."); break;
                default: System.out.println("\nOpción inválida.");
            }
        }
    }
}
