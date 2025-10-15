#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

// Función que ajusta el heap para mantener la propiedad del montículo
void heapify(int arr[], int n, int i) {
    int mayor = i;           // Se asume que la raíz es la mayor
    int izq = 2 * i + 1;     // Hijo izquierdo
    int der = 2 * i + 2;     // Hijo derecho

    // Verificar si el hijo izquierdo es mayor que la raíz
    if (izq < n && arr[izq] > arr[mayor])
        mayor = izq;

    // Verificar si el hijo derecho es mayor que el mayor actual
    if (der < n && arr[der] > arr[mayor])
        mayor = der;

    // Si el mayor no es la raíz, intercambiar y seguir ajustando
    if (mayor != i) {
        swap(arr[i], arr[mayor]);
        heapify(arr, n, mayor);
    }
}

// Ordenamiento Heap Sort
void heapSort(int arr[], int n) {
    // 1️⃣ Construir el heap máximo
    for (int i = n / 2 - 1; i >= 0; i--)
        heapify(arr, n, i);

    // 2️⃣ Extraer elementos uno a uno del heap
    for (int i = n - 1; i > 0; i--) {
        swap(arr[0], arr[i]);   // Mover el mayor al final
        heapify(arr, i, 0);     // Ajustar el heap reducido
    }
}

int main() {
    srand(time(0));
    int n = 10;
    int arr[n];

    // Generar números aleatorios entre 1 y 100
    for (int i = 0; i < n; i++)
        arr[i] = rand() % 100 + 1;

    cout << "Arreglo original: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    heapSort(arr, n);

    cout << "Arreglo ordenado: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
        cout << endl;

    return 0;
}

