//ACTIVIDAD 2: Como declarar un tipo de dato abstracto 
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 28/agosto/2025
//Materia: Estructura de Datos


using System;

// Definición de la clase Persona
class Persona
{
    public string Nombre;  // atributo Nombre
    public int Edad;       // atributo Edad

    // Constructor que recibe nombre y edad
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}

class Program
{
    static void Main()
    {
        // Arreglo de objetos Persona
        Persona[] personas = {
            new Persona("Ana", 25),
            new Persona("Luis", 30),
            new Persona("Maria", 22)
        };

        // Recorrer arreglo y mostrar datos
        foreach (Persona p in personas)
        {
            Console.WriteLine(p.Nombre + " " + p.Edad);
        }
    }
}
