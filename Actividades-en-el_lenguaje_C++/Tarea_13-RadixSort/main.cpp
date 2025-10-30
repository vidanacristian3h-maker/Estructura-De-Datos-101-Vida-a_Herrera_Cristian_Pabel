#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

// Función para obtener el valor máximo del arreglo
int obtenerMax(int arr[], int n) {
    int max = arr[0];
    for (int i = 1; i < n; i++)
        if (arr[i] > max)
            max = arr[i];
    return max;
}

// Ordena según el dígito actual (exp = 1, 10, 100...)
void contarOrden(int arr[], int n, int exp) {
    int salida[n];
    int conteo[10] = {0};

    // Contar ocurrencias de cada dígito
    for (int i = 0; i < n; i++)
        conteo[(arr[i] / exp) % 10]++;

    // Acumular posiciones
    for (int i = 1; i < 10; i++)
        conteo[i] += conteo[i - 1];

    // Construir arreglo ordenado
    for (int i = n - 1; i >= 0; i--) {
        salida[conteo[(arr[i] / exp) % 10] - 1] = arr[i];
        conteo[(arr[i] / exp) % 10]--;
    }

    // Copiar al arreglo original
    for (int i = 0; i < n; i++)
        arr[i] = salida[i];
}

// Radix Sort principal
void radixSort(int arr[], int n) {
    int max = obtenerMax(arr, n);
    for (int exp = 1; max / exp > 0; exp *= 10)
        contarOrden(arr, n, exp);
}

int main() {
    srand(time(0));
    const int n = 15;
    int arr[n];

    // Números aleatorios
    for (int i = 0; i < n; i++) arr[i] = rand() % 1000;

    cout << "Antes: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    radixSort(arr, n);

    cout << "Despues: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
}
