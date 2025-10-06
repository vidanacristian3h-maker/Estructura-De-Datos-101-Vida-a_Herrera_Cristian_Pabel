#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

// Funci�n para mezclar dos mitades ordenadas
void merge(int arr[], int inicio, int medio, int fin) {
    int n1 = medio - inicio + 1;
    int n2 = fin - medio;

    // Arreglos temporales
    int izquierda[n1], derecha[n2];

    for (int i = 0; i < n1; i++) izquierda[i] = arr[inicio + i];
    for (int j = 0; j < n2; j++) derecha[j] = arr[medio + 1 + j];

    int i = 0, j = 0, k = inicio;

    // Mezclar
    while (i < n1 && j < n2) {
        if (izquierda[i] <= derecha[j]) {
            arr[k] = izquierda[i];
            i++;
        } else {
            arr[k] = derecha[j];
            j++;
        }
        k++;
    }

    // Copiar lo que sobra
    while (i < n1) arr[k++] = izquierda[i++];
    while (j < n2) arr[k++] = derecha[j++];
}

// Funci�n MergeSort (recursiva)
void mergeSort(int arr[], int inicio, int fin) {
    if (inicio < fin) {
        int medio = (inicio + fin) / 2;
        mergeSort(arr, inicio, medio);
        mergeSort(arr, medio + 1, fin);
        merge(arr, inicio, medio, fin);
    }
}

int main() {
    srand(time(0));
    const int n = 15;
    int arr[n];

    for (int i = 0; i < n; i++) arr[i] = rand() % 100;

    cout << "Antes: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    mergeSort(arr, 0, n - 1);

    cout << "Despues: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
}
