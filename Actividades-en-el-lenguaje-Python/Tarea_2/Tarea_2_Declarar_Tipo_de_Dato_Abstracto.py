#ACTIVIDAD 2: Como declarar un tipo de dato abstracto 
#Alumno: Cristian Pabel Vidaña Herrera
#Fecha: 28/agosto/2025
#Materia: Estructura de Datos

# Definición de la clase Persona
class Persona:
    def __init__(self, nombre, edad):  # constructor que recibe nombre y edad
        self.nombre = nombre           # atributo nombre
        self.edad = edad               # atributo edad

# Lista de personas (arreglo de objetos)
personas = [
    Persona("Ana", 25),
    Persona("Luis", 30),
    Persona("Maria", 22)
]

# Recorrer la lista y mostrar los datos
for p in personas:
    print(p.nombre, p.edad)  # imprime nombre y edad de cada persona

