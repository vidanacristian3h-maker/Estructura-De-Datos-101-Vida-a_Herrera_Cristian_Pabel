#include <iostream>
using namespace std;

struct Nodo {
    int dato;
    Nodo* siguiente;
};

Nodo* front = nullptr;
Nodo* rear = nullptr;

void insertar() {
    int elemento;
    cout << "\nIngrese el elemento: ";
    cin >> elemento;

    Nodo* nuevo = new Nodo();
    nuevo->dato = elemento;
    nuevo->siguiente = nullptr;

    if (front == nullptr && rear == nullptr) {
        front = rear = nuevo;
    } else {
        rear->siguiente = nuevo;
        rear = nuevo;
    }

    cout << "\nElemento insertado correctamente.\n";
}

void eliminar() {
    if (front == nullptr) {
        cout << "\nSUBDESBORDAMIENTO (UNDERFLOW)\n";
        return;
    }

    Nodo* temp = front;
    int elemento = temp->dato;

    if (front == rear) {
        front = rear = nullptr;
    } else {
        front = front->siguiente;
    }

    delete temp;
    cout << "\nElemento eliminado: " << elemento << "\n";
}

void mostrar() {
    if (front == nullptr) {
        cout << "\nLa cola está vacía.\n";
        return;
    }

    cout << "\nElementos en la cola:\n";
    Nodo* temp = front;
    while (temp != nullptr) {
        cout << temp->dato << "\n";
        temp = temp->siguiente;
    }
}

int main() {
    int opcion = 0;
    while (opcion != 4) {
        cout << "\n*************** MENU PRINCIPAL ***************\n";
        cout << "1. Insertar un elemento\n";
        cout << "2. Eliminar un elemento\n";
        cout << "3. Mostrar la cola\n";
        cout << "4. Salir\n";
        cout << "Ingrese su opción: ";
        cin >> opcion;

        switch (opcion) {
            case 1: insertar(); break;
            case 2: eliminar(); break;
            case 3: mostrar(); break;
            case 4: cout << "\nSaliendo del programa...\n"; break;
            default: cout << "\nOpción inválida. Intente nuevamente.\n";
        }
    }
    return 0;
}
