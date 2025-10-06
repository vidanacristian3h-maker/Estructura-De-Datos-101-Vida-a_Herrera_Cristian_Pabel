#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

//Alumno: Cristian Pabel Vidaña Herrera
//grupo 201

//EXAMEN DE HERMAN PARTE 2D

//3D ordenar subarreglos (5x5x5)
    int Arreglo[5][5][5];



int main()
{
    //para poner datos random en el arreglo
 srand(time(0));

    for (int i = 0; i < 6; i++) {
        for (int j = 0; j < 6; j++) {
            for (int k = 0; k < 6; k++) {
            Arreglo[i][j][k] = rand() % 100 + 1;
            }
        }
    }

    //Codigo para saber como esta organizado el array
cout << "El arreglo es: ";
cout << "-------------------------------" << endl;
    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            for (int k = 0; k < 5; k++) {
            cout << Arreglo[i][j][k] << " ";
            }
            cout << endl;
        }
        cout << endl;
    }
cout << "-------------------------------" << endl;

    //Codigo para ordenar los subarreglos
    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            // Bubble Sort para cada subarreglo Arreglo[i][j][]
            bool swapped;
            do {
                swapped = false;
                for (int k = 0; k < 5 - 1; k++) {
                    if (Arreglo[i][j][k] > Arreglo[i][j][k + 1]) {
                        int temp = Arreglo[i][j][k];
                        Arreglo[i][j][k] = Arreglo[i][j][k + 1];
                        Arreglo[i][j][k + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
    //Codigo para saber como quedo organizado el array
cout << "El arreglo ordenado es: ";
cout << "-------------------------------" << endl;
    for (int i = 0; i < 5; i++) {
        for (int j = 0; j < 5; j++) {
            for (int k = 0; k < 5; k++) {
            cout << Arreglo[i][j][k] << " ";
            }
            cout << endl;
        }
        cout << endl;
    }
cout << "-------------------------------" << endl;


    return 0;
}
