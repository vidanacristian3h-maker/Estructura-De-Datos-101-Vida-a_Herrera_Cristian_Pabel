#ACTIVIDAD 1: Como declarar un arreglo/inicializarlo, Asignar/modificar valores, Recorrer un arreglo
#Alumno: Cristian Pabel Vidaña Herrera
#Fecha: 27/agosto/2025
#Materia: Estructura de Datos



#Declarar/inicializar un arreglo

Arreglo1 = [0] * 5#Arreglo vacio
Arreglo2 = [1,2,3,4,5] #Arreglo con valores enteros
Arreglo3 = ['a','b','c','d','e'] #Arreglo con valores tipo string
Arreglo4 = [1,'b',3.5,True] #Arreglo con valores mixtos



#Asignar/modificar valores en un arreglo
Arreglo1[0] = 10 



#Recuperacion/leer valores de un arreglo
valor = Arreglo2[2] #Recuperar el valor en la posicion 2 del arreglo2
print("El valor en la posicion 2 del Arreglo2 es:", valor)



#Analisis/Recorrer un arreglo

print("Recorriendo el Arreglo3:")
for elemento in Arreglo3:
    print(elemento)
    
