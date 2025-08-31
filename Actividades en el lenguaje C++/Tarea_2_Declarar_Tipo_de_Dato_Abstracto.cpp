//ACTIVIDAD 2: Como declarar un tipo de dato abstracto 
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 28/agosto/2025
//Materia: Estructura de Datos


#include <iostream>
using namespace std;

// Definición de la estructura Persona
struct Persona {
    string nombre;  // atributo nombre
    int edad;       // atributo edad
};

int main() {
    // Arreglo de estructuras Persona
    Persona personas[3] = {
        {"Ana", 25},
        {"Luis", 30},
        {"Maria", 22}
    };

    // Recorrer arreglo y mostrar datos
    for (int i = 0; i < 3; i++) {
        cout << personas[i].nombre << " " << personas[i].edad << endl;
    }

    return 0;
}

