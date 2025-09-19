//Actividad: Tarea 3 Arreglos 3 En Uno
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 1/Septiembre/2025
//Materia: Estructura de Datos

//• Realizar un algoritmo que haga el recorrido de un arreglo e imprima sus valores. 



#include <iostream>

int main() {

    int arreglo[5] = {1, 2, 3, 4, 5};

    std:: cout << "Elementos del arreglo: ";
    for (int i = 0; i < 5; i++) {
        std::cout << arreglo[i] << " ";
    }


//• Algoritmo que inserte un valor en un índice (posición) determinado.
int posicion, ValorAgregar;
    std::cout << "\nIngrese la posicion (0-4) donde desea insertar un valor: ";
    std::cin >> posicion;
    std::cout << "Ingrese el valor que desea insertar: ";
    std::cin >> ValorAgregar;
    if (posicion >= 0 && posicion < 5) {
        arreglo[posicion] = ValorAgregar;
        std::cout << "Valor insertado correctamente.\n";
    } else {
        std::cout << "Posicion invalida.\n";
    }
    std::cout << "Elementos del arreglo despues de la insercion: ";
    for (int i = 0; i < 5; i++) {
        std::cout << arreglo[i] << " ";
    }

    std::cout << std::endl;

//• ⁠Algoritmo que implemente la búsqueda lineal de un elemento en un arreglo.
    int ValorBuscar;
    std::cout << "\nIngrese el valor que desea buscar en el arreglo: ";
    std::cin >> ValorBuscar;

    for (int i = 0; i < 5; i++) {
        if (arreglo[i] == ValorBuscar) {
            std::cout << "Valor " << ValorBuscar << " encontrado en la posicion " << i << ".\n";
            break;
        }
        if (i == 4) {
            std::cout << "Valor " << ValorBuscar << " no encontrado en el arreglo.\n";
        }
    }

    


    return 0;
}