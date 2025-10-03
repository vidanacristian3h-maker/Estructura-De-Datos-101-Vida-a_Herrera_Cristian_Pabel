#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
    int n = 10; 
    int numeros[n];

    srand(time(0));

    for (int i = 0; i < n; i++) {
        numeros[i] = rand() % 100 + 1;
    }

    cout << "Antes: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";
    cout << endl;


    // Bubble Sort
    bool swapped;
    do {
        swapped = false;
        //aquí se compara cada elemento con el siguiente
        for (int i = 0; i < n - 1; i++) {
            if (numeros[i] > numeros[i + 1]) {
                int temp = numeros[i]; // aqui se guarda el valor temporal
                numeros[i] = numeros[i + 1]; // aqui se intercambian los valores
                numeros[i + 1] = temp; // aqui se asigna el valor temporal
                swapped = true; // si se hizo un intercambio, se marca como true
            }
        }
    } while (swapped); // si no se hicieron intercambios, el arreglo está ordenado

    cout << "Después: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";

    return 0;
}
