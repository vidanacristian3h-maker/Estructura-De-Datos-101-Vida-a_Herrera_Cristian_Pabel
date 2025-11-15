import java.util.InputMismatchException;
import java.util.Scanner;

// Programa en Java para manejar una lista doblemente enlazada

public class ListaDoble {

    /**
     * Definición de la estructura del nodo para la lista doblemente enlazada
     */
    static class Node {
        int data;  // Almacena el valor numérico del nodo
        Node next; // Apunta al siguiente nodo en la lista
        Node prev; // Apunta al nodo anterior en la lista

        // Constructor del nodo
        public Node(int data) {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }

    /**
     * Clase que encapsula la lógica de la lista doblemente enlazada
     */
    static class DoublyLinkedList {
        
        // Puntero que apunta al primer nodo (head)
        private Node head = null;

        /**
         * Inserta un nodo al principio de la lista
         */
        public void beginInsert(Scanner scanner) {
            try {
                System.out.print("\nIngrese valor: ");
                int item = scanner.nextInt();
                Node ptr = new Node(item);

                if (head == null) {
                    head = ptr;
                } else {
                    ptr.next = head;
                    head.prev = ptr;
                    head = ptr;
                }
                System.out.println("\nNodo insertado al principio.");
            } catch (InputMismatchException e) {
                System.out.println("\nError: Ingrese un número válido.");
                scanner.next(); // Limpia el buffer de entrada
            }
        }

        /**
         * Inserta un nodo al final de la lista
         */
        public void lastInsert(Scanner scanner) {
            try {
                System.out.print("\nIngrese valor: ");
                int item = scanner.nextInt();
                Node ptr = new Node(item);

                if (head == null) {
                    head = ptr;
                } else {
                    Node temp = head;
                    // Recorre hasta el último nodo
                    while (temp.next != null) {
                        temp = temp.next;
                    }
                    temp.next = ptr;
                    ptr.prev = temp;
                }
                System.out.println("\nNodo insertado al final.");
            } catch (InputMismatchException e) {
                System.out.println("\nError: Ingrese un número válido.");
                scanner.next(); // Limpia el buffer de entrada
            }
        }

        /**
         * Inserta un nodo después de una posición específica (índice 0)
         */
        public void randomInsert(Scanner scanner) {
            if (head == null) {
                System.out.println("\nLa lista está vacía.");
                return;
            }

            try {
                System.out.print("\nIntroduzca el valor del elemento: ");
                int item = scanner.nextInt();
                System.out.print("\nIntroduce la ubicación (índice 0) después de la cual deseas insertar: ");
                int loc = scanner.nextInt();

                Node ptr = new Node(item);
                Node temp = head;

                // Avanza hasta la posición 'loc'
                for (int i = 0; i < loc; i++) {
                    if (temp == null) {
                        System.out.println("\nNo se puede insertar, posición fuera de rango.");
                        return;
                    }
                    temp = temp.next;
                }

                if (temp == null) {
                    System.out.println("\nNo se puede insertar, posición fuera de rango.");
                    return;
                }

                ptr.next = temp.next;
                ptr.prev = temp;
                if (temp.next != null) {
                    temp.next.prev = ptr;
                }
                temp.next = ptr;

                System.out.println("\nNodo insertado en la posición indicada.");
            } catch (InputMismatchException e) {
                System.out.println("\nError: Ingrese un número válido.");
                scanner.next(); // Limpia el buffer de entrada
            }
        }

        /**
         * Elimina el primer nodo de la lista
         */
        public void beginDelete() {
            if (head == null) {
                System.out.println("\nLa lista está vacía.");
                return;
            }
            
            head = head.next;
            if (head != null) {
                head.prev = null;
            }
            // El 'garbage collector' de Java se encarga de liberar la memoria del nodo anterior
            System.out.println("\nNodo eliminado desde el principio.");
        }

        /**
         * Elimina el último nodo de la lista
         */
        public void lastDelete() {
            if (head == null) {
                System.out.println("\nLa lista está vacía.");
                return;
            }

            if (head.next == null) { // Si solo hay un nodo
                head = null;
                System.out.println("\nSolo se eliminó un nodo de la lista.");
                return;
            }

            Node temp = head;
            while (temp.next != null) {
                temp = temp.next;
            }
            // temp es el último nodo
            temp.prev.next = null; // El penúltimo nodo ahora apunta a null
            System.out.println("\nNodo eliminado del final.");
        }

        /**
         * Elimina un nodo en una posición específica (índice 0)
         */
        public void randomDelete(Scanner scanner) {
            if (head == null) {
                System.out.println("\nLa lista está vacía.");
                return;
            }

            try {
                System.out.print("\nIntroduzca la ubicación (índice 0) del nodo a eliminar: ");
                int loc = scanner.nextInt();

                Node temp = head;
                // Avanza hasta el nodo en la posición 'loc'
                for (int i = 0; i < loc; i++) {
                    if (temp == null) {
                        System.out.println("\nNo se puede eliminar, posición fuera de rango.");
                        return;
                    }
                    temp = temp.next;
                }

                if (temp == null) {
                    System.out.println("\nNo se puede eliminar, posición fuera de rango.");
                    return;
                }

                // Reconecta los nodos
                if (temp.prev != null) {
                    temp.prev.next = temp.next;
                }
                if (temp.next != null) {
                    temp.next.prev = temp.prev;
                }
                
                // Caso especial: si eliminamos el primer nodo (loc = 0)
                if (temp == head) {
                    head = temp.next;
                }

                System.out.println("\nNodo eliminado correctamente.");

            } catch (InputMismatchException e) {
                System.out.println("\nError: Ingrese un número válido.");
                scanner.next(); // Limpia el buffer de entrada
            }
        }

        /**
         * Busca un elemento en la lista y muestra su posición
         */
        public void search(Scanner scanner) {
            if (head == null) {
                System.out.println("\nLista vacía.");
                return;
            }

            try {
                System.out.print("\nIntroduce el elemento que deseas buscar: ");
                int item = scanner.nextInt();
                
                Node temp = head;
                int pos = 1; // Usamos índice basado en 1 para mostrar
                boolean found = false;

                while (temp != null) {
                    if (temp.data == item) {
                        System.out.printf("Elemento encontrado en la ubicación %d\n", pos);
                        found = true;
                    }
                    temp = temp.next;
                    pos++;
                }

                if (!found) {
                    System.out.println("Elemento no encontrado.");
                }
            } catch (InputMismatchException e) {
                System.out.println("\nError: Ingrese un número válido.");
                scanner.next(); // Limpia el buffer de entrada
            }
        }

        /**
         * Muestra todos los elementos de la lista
         */
        public void display() {
            if (head == null) {
                System.out.println("Nada que imprimir.");
                return;
            }

            System.out.println("\nImprimiendo valores...");
            Node temp = head;
            while (temp != null) {
                System.out.print(temp.data + " ");
                temp = temp.next;
            }
            System.out.println(); // Salto de línea al final
        }
    }


    // --- Función principal (main) ---
    public static void main(String[] args) {
        // Creamos un único scanner para toda la aplicación
        Scanner scanner = new Scanner(System.in);
        // Creamos una instancia de nuestra lista
        DoublyLinkedList list = new DoublyLinkedList();
        
        int choice = 0;

        while (choice != 9) {
            System.out.println("\n\n********Menú principal********");
            System.out.println("Elige una opción de la siguiente lista...");
            System.out.println("================================");
            System.out.println("1. Insertar al principio\t2. Insertar al final\t3. Insertar en una posición específica");
            System.out.println("4. Eliminar del principio\t5. Eliminar desde el último\t6. Eliminar nodo después de la ubicación especificada");
            System.out.println("7. Buscar un elemento\t\t8. Mostrar\t\t9. Salir");
            System.out.print("\nIngrese su opción:\t");

            try {
                choice = scanner.nextInt();

                switch (choice) {
                    case 1:
                        list.beginInsert(scanner);
                        break;
                    case 2:
                        list.lastInsert(scanner);
                        break;
                    case 3:
                        list.randomInsert(scanner);
                        break;
                    case 4:
                        list.beginDelete();
                        break;
                    case 5:
                        list.lastDelete();
                        break;
                    case 6:
                        list.randomDelete(scanner);
                        break;
                    case 7:
                        list.search(scanner);
                        break;
                    case 8:
                        list.display();
                        break;
                    case 9:
                        System.out.println("Saliendo del programa...");
                        break;
                    default:
                        System.out.println("Introduzca una opción válida (1-9).");
                }
            } catch (InputMismatchException e) {
                System.out.println("\nError: Introduzca una opción válida (un número).");
                scanner.next(); // Limpia el buffer de entrada
                choice = 0; // Resetea la elección para que el bucle continúe
            }
        }
        
        scanner.close(); // Cierra el scanner al salir
    }
}