#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

//Defino una arreglo de 10 elementos

int arreglo [10];
int num;


int main()
{
    //para poner datos random en el arreglo
 srand(time(0));

    for (int i = 0; i < 10; i++) {
        arreglo[i] = rand() % 100 + 1;
    }

//codigo para checar como quedo antes
cout << "Antes: ";
    for (int i = 0; i < 10; i++) cout << arreglo[i] << " ";
    cout << endl;


//codigo para ordenar el arreglo
// Bubble Sort
    bool swapped;
    do {
        swapped = false;
        //aquí se compara cada elemento con el siguiente
        for (int i = 0; i < 10 - 1; i++) {
            if (arreglo[i] > arreglo[i + 1]) {
                int temp = arreglo[i]; // aqui se guarda el valor temporal
                arreglo[i] = arreglo[i + 1]; // aqui se intercambian los valores
                arreglo[i + 1] = temp; // aqui se asigna el valor temporal
                swapped = true; // si se hizo un intercambio, se marca como true
            }
        }
    } while (swapped); // si no se hicieron intercambios, el arreglo está ordenado


//codigo para checar como quedo despues
    cout << "Después: ";
    for (int i = 0; i < 10; i++) cout << arreglo[i] << " ";
    bool No_Encontro_Elemento = true;

    std:: cout << "Que numero quieres buscar? ";
    
    std:: cin >> num;

    for (int i = 0; i < 10; i++) {
        if (arreglo[i] == num) {
            std:: cout << "El numero " << num << " se encuentra en la posicion " << i << std:: endl;
            No_Encontro_Elemento = false;
            break;
        } else {
            std:: cout << "El numero " << num << " no se encuentra en el arreglo" << std:: endl;
            No_Encontro_Elemento = true;
        }
    }


} while (No_Encontro_Elemento == true);
}
