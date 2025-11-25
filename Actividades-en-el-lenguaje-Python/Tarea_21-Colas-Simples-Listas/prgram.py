class Nodo:
    def __init__(self, dato):
        self.dato = dato
        self.siguiente = None

front = None
rear = None

def insertar():
    global front, rear
    elemento = int(input("\nIngrese el elemento: "))
    nuevo = Nodo(elemento)

    if front is None and rear is None:
        front = rear = nuevo
    else:
        rear.siguiente = nuevo
        rear = nuevo

    print("\nElemento insertado correctamente.")

def eliminar():
    global front, rear
    if front is None:
        print("\nSUBDESBORDAMIENTO (UNDERFLOW)")
        return

    elemento = front.dato

    if front == rear:
        front = rear = None
    else:
        front = front.siguiente

    print(f"\nElemento eliminado: {elemento}")

def mostrar():
    if front is None:
        print("\nLa cola está vacía.")
        return

    print("\nElementos en la cola:")
    temp = front
    while temp:
        print(temp.dato)
        temp = temp.siguiente

opcion = 0

while opcion != 4:
    print("\n*************** MENU PRINCIPAL ***************")
    print("1. Insertar un elemento")
    print("2. Eliminar un elemento")
    print("3. Mostrar la cola")
    print("4. Salir")
    opcion = int(input("Ingrese su opción: "))

    if opcion == 1: insertar()
    elif opcion == 2: eliminar()
    elif opcion == 3: mostrar()
    elif opcion == 4: print("\nSaliendo del programa...")
    else: print("\nOpción inválida.")
