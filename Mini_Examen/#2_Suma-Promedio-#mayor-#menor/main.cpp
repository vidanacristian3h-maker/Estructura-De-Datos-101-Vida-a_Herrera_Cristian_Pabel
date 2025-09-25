#include <iostream>

// EXAMEN version 2# del pintarron

//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 24/09/2025
//Grupo:201
// -Calcular suma, promedio
// #maximo y minimo

// Arreglo para 10 números (índices 0-9)
float Numero[10];
float acumulador = 0;

int main() {
    // 1. Capturar los números y calcular la suma
    std::cout << "--- Captura de 10 numeros ---\n";
    for (int i = 0; i < 10; i++) {
        std::cout << "Inserta el numero " << i + 1 << ": "; // Usamos i+1 para que el usuario vea 1-10
        std::cin >> Numero[i];
        acumulador += Numero[i];
    }
    std::cout << "\n-----------------------------------\n";

    // 2. Mostrar la suma
    std::cout << "La suma de los numeros capturados es: " << acumulador << "\n";

    // 3. Calcular y mostrar el promedio
    float promedio = acumulador / 10;
    std::cout << "El promedio de los numeros que capturaste es: " << promedio << "\n";

    // 4. Encontrar y mostrar el número máximo y mínimo
    // Inicializamos ambas variables con el primer número del arreglo.
    float NumeroMenor = Numero[0];
    float NumeroMayor = Numero[0];

    // Recorremos el arreglo DESDE EL SEGUNDO elemento (índice 1)
    // porque ya usamos el primero para inicializar.
    for (int i = 1; i < 10; i++) {
        // Si encontramos un número más pequeño, lo guardamos.
        if (Numero[i] < NumeroMenor) {
            NumeroMenor = Numero[i];
        }
        // Si encontramos un número más grande, lo guardamos.
        if (Numero[i] > NumeroMayor) {
            NumeroMayor = Numero[i];
        }
    }

    std::cout << "El numero menor es: " << NumeroMenor << "\n";
    std::cout << "El numero mayor es: " << NumeroMayor << "\n";

    return 0;
}
