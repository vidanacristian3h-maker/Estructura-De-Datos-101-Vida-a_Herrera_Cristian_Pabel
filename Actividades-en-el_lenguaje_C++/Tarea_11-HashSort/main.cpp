#include <iostream>
#include <map>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
    srand(time(0));
    int n = 10;
    int arr[n];

    // Generar números aleatorios entre 0 y 50
    for (int i = 0; i < n; i++)
        arr[i] = rand() % 51;

    cout << "Arreglo original: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
    cout << endl;

    // Usar map (clave ordenada) como "hash"
    map<int, int> hash;

    // Contar ocurrencias
    for (int i = 0; i < n; i++)
        hash[arr[i]]++;

    // Reconstruir arreglo ordenado
    int index = 0;
    for (auto &par : hash) {
        for (int j = 0; j < par.second; j++)
            arr[index++] = par.first;
    }

    cout << "Arreglo ordenado: ";
    for (int i = 0; i < n; i++) cout << arr[i] << " ";
        cout << endl;

    return 0;
}

