#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

// Función QuickSort (recursiva)
void quickSort(int arr[], int inicio, int fin) {
    int i = inicio, j = fin;
    int pivote = arr[(inicio + fin) / 2]; // Pivote en el centro

    // Reordenar la lista según el pivote
    while (i <= j) {
        while (arr[i] < pivote) i++; // mover izquierda hasta encontrar mayor
        while (arr[j] > pivote) j--; // mover derecha hasta encontrar menor

        if (i <= j) {
            // intercambiar elementos
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++; j--;
        }
    }

    // Recursión en las dos mitades
    if (inicio < j) quickSort(arr, inicio, j);
    if (i < fin) quickSort(arr, i, fin);
}

int main() {
    srand(time(0)); // Semilla para números aleatorios
    const int n = 15;
    int arr[n];

    // Generar 15 números aleatorios entre 0 y 99
    for (int i = 0; i < n; i++) arr[i] = rand() % 100;

    // Mostrar antes
    cout << "Antes: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    // Ordenar con QuickSort
    quickSort(arr, 0, n - 1);

    // Mostrar después
    cout << "Despues: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
}
