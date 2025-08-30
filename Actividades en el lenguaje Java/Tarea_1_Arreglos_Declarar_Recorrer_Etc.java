//ACTIVIDAD 1: Como declarar un arreglo/inicializarlo, Asignar/modificar valores, Recorrer un arreglo
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 27/agosto/2025
//Materia: Estructura de Datos

import java.util.Scanner;

public class Tarea_1_Arreglos_Declarar_Recorrer_Etc {
    public static void main(String[] args) {


        // Declarar un arreglo de enteros con tamaño 5
        int[] numeros = new int[5];



        // Asignar/modificar valores en el arreglo
        numeros[0] = 10;
        numeros[1] = 20;
        numeros[2] = 30;
        numeros[3] = 40;
        numeros[4] = 50;



        // Recorrer el arreglo e imprimir los valores
        System.out.println("Elementos del arreglo:");
        for (int i = 0; i < 5; i++) {
            System.out.println("Elemento en indice " + i + ": " + numeros[i]);
        }


     // Pausa hasta que el usuario presione Enter
        Scanner scanner = new Scanner(System.in);
        System.out.println("Presiona Enter para salir...");
        scanner.nextLine(); 
        scanner.close();
    
    }

}
