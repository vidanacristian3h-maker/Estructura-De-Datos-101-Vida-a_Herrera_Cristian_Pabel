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
        for (int i = 0; i < n - 1; i++) {
            if (numeros[i] > numeros[i + 1]) {
                int temp = numeros[i];
                numeros[i] = numeros[i + 1];
                numeros[i + 1] = temp;
                swapped = true;
            }
        }
    } while (swapped);

    cout << "Después: ";
    for (int i = 0; i < n; i++) cout << numeros[i] << " ";

    return 0;
}
