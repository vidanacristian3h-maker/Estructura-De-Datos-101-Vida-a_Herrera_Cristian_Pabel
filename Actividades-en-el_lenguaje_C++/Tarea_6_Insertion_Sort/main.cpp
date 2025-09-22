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

    // Insertion Sort
    for (int i = 1; i < n; i++) {
        int clave = numeros[i];
        int j = i - 1;

        while (j >= 0 && numeros[j] > clave) {
            numeros[j + 1] = numeros[j];
            j--;
        }
        numeros[j + 1] = clave;
    }

    cout << "Después: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";
}
