#include <iostream>
#include <vector>
#include <algorithm>
#include <cstdlib>
#include <ctime>
using namespace std;

void bucketSort(float arr[], int n) {
    vector<float> buckets[n];

    // Colocar cada número en su cubeta correspondiente
    for (int i = 0; i < n; i++) {
        int index = n * arr[i];
        buckets[index].push_back(arr[i]);
    }

    // Ordenar cada cubeta
    for (int i = 0; i < n; i++)
        sort(buckets[i].begin(), buckets[i].end());

    // Unir todas las cubetas
    int k = 0;
    for (int i = 0; i < n; i++)
        for (float num : buckets[i])
            arr[k++] = num;
}

int main() {
    srand(time(0));
    int n = 10;
    float arr[n];

    // Generar números aleatorios entre 0 y 1
    for (int i = 0; i < n; i++)
        arr[i] = (float)rand() / RAND_MAX;

    cout << "Antes:\n";
    for (float x : arr) cout << x << " ";

    bucketSort(arr, n);

    cout << "\n\nDespués:\n";
    for (float x : arr) cout << x << " ";
        cout << endl;
    return 0;
    
}
