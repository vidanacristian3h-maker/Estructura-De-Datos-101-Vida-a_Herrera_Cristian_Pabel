#include <iostream>
#include <cstdlib> // para rand()
#include <ctime>   // para time()

using namespace std;

int main() {
    const int n = 10;
    int Numeros[n];

    srand(time(0)); // semilla para números aleatorios

    // Llenar el arreglo con números aleatorios
    for (int i = 0; i < n; i++) {
        Numeros[i] = rand() % 100 + 1;
    }

    cout << "Antes: ";
    for (int i = 0; i < n; i++) {
        cout << Numeros[i] << " ";
    }
    cout << endl;

    // ---------- Selection Sort ----------
    for (int i = 0; i < n - 1; i++) {
        int PosicionMenor = i; // asumimos que el menor está en i
        for (int j = i + 1; j < n; j++) {
            
            //comparamos para encontrar el menor
            if (Numeros[j] < Numeros[PosicionMenor]) {
                PosicionMenor = j; // encontramos un número más pequeño
            }
        }
        swap(Numeros[i], Numeros[PosicionMenor]); // intercambiamos
    }

    cout << "Despues: ";
    for (int i = 0; i < n; i++) {
        cout << Numeros[i] << " ";
    }
    cout << endl;

    return 0;
}
