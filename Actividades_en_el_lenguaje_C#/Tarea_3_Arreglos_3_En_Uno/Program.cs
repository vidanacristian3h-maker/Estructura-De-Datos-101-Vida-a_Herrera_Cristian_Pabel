//Actividad: Tarea 3 Arreglos 3 En Uno
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 1/Septiembre/2025
//Materia: Estructura de Datos

//• Realizar un algoritmo que haga el recorrido de un arreglo e imprima sus valores. 


using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;



int[] Arreglo = new int[10];


Arreglo[0]= 1;
Arreglo[1]= 2;
Arreglo[2]= 3;
Arreglo[3]= 4;
Arreglo[4]= 5;
Arreglo[5]= 6;
Arreglo[6]= 7;
Arreglo[7]= 8;
Arreglo[8]= 9;
Arreglo[9]= 10;

Console.WriteLine("Recorrido del arreglo:");
for (int i = 0; i < Arreglo.Length; i++)
{
    Console.WriteLine(Arreglo[i]);
}




//• Algoritmo que inserte un valor en un índice (posición) determinado.

int ValorAInsertar;
Console.WriteLine("-------insertar un valor en un índice determinado del arreglo--------");

int Posicion;
Console.WriteLine("Ingrese el valor a insertar:");
ValorAInsertar = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Ingrese la posición donde desea insertar el valor (0 a 9):");
Posicion = Convert.ToInt32(Console.ReadLine());

Arreglo[Posicion] = ValorAInsertar;

Console.WriteLine("Valor insertado correctamente.");

Console.WriteLine("Arreglo actualizado:");
for (int i = 0; i < Arreglo.Length; i++)
{
    Console.WriteLine(Arreglo[i]);
}




//• ⁠Algoritmo que implemente la búsqueda lineal de un elemento en un arreglo.

Console.WriteLine("---------búsqueda lineal de un elemento en un arreglo------");


Console.WriteLine("Ingrese el valor a buscar:");
int ValorABuscar = Convert.ToInt32(Console.ReadLine());

for (int i =0; i < Arreglo.Length; i++)
{
    if (Arreglo[i] == ValorABuscar)
    {
        Console.WriteLine($"Valor {ValorABuscar} encontrado en la posición {i}.");
        break;
    }
    if (i == Arreglo.Length - 1)
    {
        Console.WriteLine($"Valor {ValorABuscar} no encontrado en el arreglo.");
    }
}

