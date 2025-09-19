//ACTIVIDAD 1: Como declarar un arreglo/inicializarlo, Asignar/modificar valores, Recorrer un arreglo
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 27/agosto/2025
//Materia: Estructura de Datos

#include <iostream>
using namespace std;
int main() {
    //Declarar un arreglo de enteros con 5 elementos
    int numeros[5];

    //Asignar/modificar valores en el arreglo
    numeros[0] = 10;
    numeros[1] = 20;
    numeros[2] = 30;
    numeros[3] = 40;
    numeros[4] = 50;

    //Recorrer el arreglo e imprimir sus valores
    cout << "Elementos del arreglo:" << endl;
    for (int i = 0; i < 5; i++) {
        cout << "Elemento en indice " << i << ": " << numeros[i] << endl;
         
    }
system("pause"); // pausa para que el programa no se cierre inmediatamente
    return 0;
}

