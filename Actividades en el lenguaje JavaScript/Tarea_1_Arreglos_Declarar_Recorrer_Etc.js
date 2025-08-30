//ACTIVIDAD 1: Como declarar un arreglo/inicializarlo, Asignar/modificar valores, Recorrer un arreglo
//Alumno: Cristian Pabel Vidaña Herrera
//Fecha: 27/agosto/2025
//Materia: Estructura de Datos

// 1️⃣ Declarar e inicializar un arreglo
let Arreglo1 = [0, 0, 0, 0, 0];  // arreglo de 5 elementos inicializados en 0


// 2️⃣ Asignar o modificar valores
Arreglo1[0] = 10;   // modificar el primer elemento
Arreglo1[1] = 20;   // modificar el segundo elemento
Arreglo1[2] = 30;   // modificar el tercer elemento


// 3️⃣ Recorrer el arreglo e imprimir los valores
console.log("Recorriendo Arreglo1:");
for (let i = 0; i < Arreglo1.length; i++) {
    console.log(Arreglo1[i]);
}


// 🔹 Alternativa usando for-each
console.log("Recorriendo Arreglo1 con forEach:");
Arreglo1.forEach((elemento) => {
    console.log(elemento);
});

