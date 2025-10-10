#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

//Alumno: Cristian Pabel Vidaña Herrera
//grupo 201

//EXAMEN DE HERMAN PARTE 2D

//2D ENCONTRAR EL VALOR MAXIMO  EN UN ARREGLO (6X6)

 int Arreglo[6][6];


int main()
{
        //para poner datos random en el arreglo
 srand(time(0));

    for (int i = 0; i < 6; i++) {
        for (int j = 0; j < 6; j++) {
            Arreglo[i][j] = rand() % 100 + 1;
        }
    }

    //Codigo para saber como esta organizado el array
cout << "El arreglo es: ";
    for (int i = 0; i < 6; i++) {
        for (int j = 0; j < 6; j++) {
            cout << Arreglo[i][j] << " ";
        }
        cout << endl;
    }

    //Codigo para encontrar el valor maximo
    int max = Arreglo[0][0];
    for (int i = 0; i < 6; i++) {
        for (int j = 0; j < 6; j++) {
            if (Arreglo[i][j] > max) {
                max = Arreglo[i][j];
            }
        }
    }
    cout << "El valor maximo es: " << max << endl;


    return 0;
}
