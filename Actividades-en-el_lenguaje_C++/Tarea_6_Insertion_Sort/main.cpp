#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
    int n = 10;
    int numeros[n];

    srand(time(0)); // Semilla para números aleatorios

    // Llenar el arreglo con números aleatorios entre 1 y 100
    for (int i = 0; i < n; i++) {
        numeros[i] = rand() % 100 + 1;
    }

    // Mostrar el arreglo antes de ordenar

    cout << "Antes: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";
    cout << endl;


    // Insertion Sort
    for (int i = 1; i < n; i++) {
        int clave = numeros[i]; // Elemento a insertar
        int j = i - 1; // Índice del elemento anterior

        // Mover los elementos del arreglo que son mayores que la clave
        while (j >= 0 && numeros[j] > clave) {
            numeros[j + 1] = numeros[j]; // Desplazar el elemento hacia la derecha
            j--; // Mover al siguiente elemento a la izquierda
        }
        numeros[j + 1] = clave; // Insertar la clave en su posición correcta
    }

    // Mostrar el arreglo después de ordenar
    cout << "Después: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";
}
