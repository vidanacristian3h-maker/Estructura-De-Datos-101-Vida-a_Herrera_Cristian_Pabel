import sys

# Definición de la clase Nodo (equivalente a struct node)
class Node:
    """
    Estructura del nodo para la lista enlazada.
    """
    def __init__(self, data):
        self.data = data  # Almacena el valor numérico del nodo
        self.next = None  # Puntero que apunta al siguiente nodo en la lista

class LinkedList:
    """
    Clase que maneja todas las operaciones de la lista enlazada.
    """
    def __init__(self):
        # El 'head' ahora es un atributo de la clase
        self.head = None

    # --- Función begin_insert() ---
    def begin_insert(self):
        """
        Inserta un nuevo nodo al principio de la lista.
        """
        try:
            item = int(input("\nIngrese valor: "))
            new_node = Node(item)
            
            # Configura el nuevo nodo
            new_node.next = self.head  # El siguiente del nuevo nodo será el actual head
            self.head = new_node      # El nuevo nodo se convierte en el head
            print("\nNodo insertado")
            
        except ValueError:
            print("\nError: Por favor, ingrese un número válido.")
        # Nota: El 'OVERFLOW' (error de memoria) es manejado por Python 
        # automáticamente levantando una MemoryError.

    # --- Función last_insert() ---
    def last_insert(self):
        """
        Inserta un nuevo nodo al final de la lista.
        """
        try:
            item = int(input("\nIngrese valor: "))
            new_node = Node(item)
            new_node.next = None # El nuevo nodo será el último

            # Caso especial: lista vacía
            if self.head is None:
                self.head = new_node
                print("\nNodo insertado")
            else:
                # Recorre la lista hasta encontrar el último nodo
                temp = self.head
                while temp.next is not None:
                    temp = temp.next
                
                temp.next = new_node  # Inserta el nuevo nodo al final
                print("\nNodo insertado")

        except ValueError:
            print("\nError: Por favor, ingrese un número válido.")
            
    # --- Función random_insert() ---
    def random_insert(self):
        """
        Inserta un nuevo nodo después de una posición específica (índice 0).
        """
        try:
            item = int(input("\nIntroduzca el valor del elemento: "))
            # La ubicación 'loc' es el índice (empezando en 0)
            loc = int(input("\nIntroduce la ubicación (índice 0) después de la cual deseas insertar: "))
            
            new_node = Node(item)
            temp = self.head

            if temp is None:
                 print("\nLa lista está vacía, no se puede insertar.")
                 return

            # Avanza hasta la posición deseada
            # El bucle se detiene en el nodo en la posición 'loc'
            for i in range(loc):
                if temp.next is None:
                    print("\nNo se puede insertar, ubicación fuera de rango.")
                    return
                temp = temp.next
            
            # Realiza la inserción
            new_node.next = temp.next  # El nuevo nodo apunta al siguiente del actual
            temp.next = new_node       # El nodo actual apunta al nuevo
            print("\nNodo insertado")

        except ValueError:
            print("\nError: Por favor, ingrese un número válido para el valor o la ubicación.")
        except AttributeError:
             # Esto ocurre si la lista está vacía (temp es None) y se intenta temp.next
             print("\nNo se puede insertar, ubicación fuera de rango.")


    # --- Función begin_delete() ---
    def begin_delete(self):
        """
        Elimina el primer nodo de la lista.
        """
        if self.head is None:
            print("\nLa lista está vacía")
        else:
            # Guarda el primer nodo (para que Python lo elimine)
            ptr = self.head
            # Actualiza head para que apunte al segundo nodo
            self.head = ptr.next
            # Python se encarga de liberar la memoria de 'ptr' (garbage collection)
            print("\nNodo eliminado desde el principio ...")

    # --- Función last_delete() ---
    def last_delete(self):
        """
        Elimina el último nodo de la lista.
        """
        if self.head is None:
            print("\nLa lista está vacía")
        # Caso especial: solo hay un nodo
        elif self.head.next is None:
            self.head = None
            print("\nSolo se eliminó un nodo de la lista ...")
        # Caso general: más de un nodo
        else:
            ptr = self.head
            ptr1 = None # Puntero al nodo anterior
            
            # Recorre la lista hasta el último nodo
            # ptr1 mantiene el penúltimo nodo
            while ptr.next is not None:
                ptr1 = ptr       # Guarda el nodo actual
                ptr = ptr.next   # Avanza al siguiente
            
            ptr1.next = None  # El penúltimo se convierte en último
            print("\nNodo eliminado del último ...")

    # --- Función random_delete() ---
    def random_delete(self):
        """
        Elimina un nodo después de una posición específica (índice 0).
        Nota: El código C++ original tiene un error grave (segfault)
        si se intenta eliminar después de la pos 0. Esta versión
        implementa la lógica *intencionada* (y correcta).
        """
        try:
            loc = int(input("\nIntroduzca la ubicación (índice 0) del nodo DESPUÉS del cual desea eliminar: "))
            
            ptr = self.head
            if ptr is None:
                print("\nLa lista está vacía.")
                return

            # Avanza hasta la posición 'loc'
            for i in range(loc):
                if ptr.next is None:
                    print("\nUbicación fuera de rango.")
                    return
                ptr = ptr.next

            # 'ptr' es el nodo en la posición 'loc'
            # Queremos eliminar 'ptr.next'
            if ptr.next is None:
                print("\nNo se puede eliminar, no hay nodo después de esta ubicación.")
                return

            # El nodo a eliminar es ptr.next
            nodo_a_eliminar = ptr.next
            # Reconecta el nodo 'ptr' con el nodo 'ptr.next.next'
            ptr.next = nodo_a_eliminar.next 
            
            print(f"\nNodo eliminado después de la posición {loc}")

        except ValueError:
            print("\nError: Por favor, ingrese un número válido para la ubicación.")
        except AttributeError:
            print("\nNo se puede eliminar, ubicación fuera de rango.")


    # --- Función search() ---
    def search(self):
        """
        Busca un elemento en la lista y muestra su posición.
        Nota: El código C++ original tenía un error lógico en la bandera
        (flag). Esta versión está corregida.
        """
        if self.head is None:
            print("\nLista vacía")
            return
            
        try:
            item = int(input("\nIntroduce el elemento que deseas buscar: "))
            ptr = self.head
            i = 0       # Contador de posición (índice 0)
            found = False # Bandera para indicar si se encontró el elemento

            # Recorre la lista completa
            while ptr is not None:
                if ptr.data == item:
                    print(f"Elemento encontrado en la ubicación {i + 1}")
                    found = True
                i += 1
                ptr = ptr.next # Avanza al siguiente nodo
            
            if not found:
                print("Elemento no encontrado")
                
        except ValueError:
            print("\nError: Por favor, ingrese un número válido.")

    # --- Función display() ---
    def display(self):
        """
        Muestra todos los elementos de la lista.
        """
        ptr = self.head
        if ptr is None:
            print("\nNada que imprimir")
        else:
            print("\nimprimiendo valores . . .")
            while ptr is not None:
                print(ptr.data) # Imprime el valor del nodo actual
                ptr = ptr.next  # Avanza al siguiente nodo


# --- Función principal (main) ---
def main():
    """
    Función principal que ejecuta el menú.
    """
    
    # Crea una instancia de la lista enlazada
    mi_lista = LinkedList()
    
    while True:
        print("\n\n********Menú principal********")
        print("\nElige una opción de la siguiente lista...")
        print("================================")
        print("1. Insertar al principio\t2. Insertar al final\t3. Insertar en una posición específica")
        print("4. Eliminar del principio\t5. Eliminar desde el último\t6. Eliminar nodo después de la ubicación especificada")
        print("7. Buscar un elemento\t\t8. Mostrar\t\t9. Salir")
        
        try:
            choice = int(input("\nIngrese su opción: "))
        except ValueError:
            print("\nIntroduzca una opción válida (un número).")
            continue # Vuelve al inicio del bucle

        # Evalúa la opción seleccionada (reemplaza 'switch' con 'if/elif/else')
        if choice == 1:
            mi_lista.begin_insert()
        elif choice == 2:
            mi_lista.last_insert()
        elif choice == 3:
            mi_lista.random_insert()
        elif choice == 4:
            mi_lista.begin_delete()
        elif choice == 5:
            mi_lista.last_delete()
        elif choice == 6:
            mi_lista.random_delete()
        elif choice == 7:
            mi_lista.search()
        elif choice == 8:
            mi_lista.display()
        elif choice == 9:
            sys.exit(0) # Sale del programa
        else:
            print("\nIntroduzca una opción válida (1-9).")

# --- Punto de entrada del script ---
# Esto asegura que main() solo se ejecute cuando el script es
# ejecutado directamente (no cuando es importado).
if __name__ == "__main__":
    main()