// Actividad: Tarea 3 Arreglos 3 En Uno
// Alumno: Cristian Pabel Vidaña Herrera
// Fecha: 1/Septiembre/2025
// Materia: Estructura de Datos

const readline = require("readline").createInterface({
    input: process.stdin,
    output: process.stdout
});

let arreglo = [1, 2, 3, 4, 5];
console.log("Recorrido e impresión de valores de un arreglo:");
for (let i = 0; i < arreglo.length; i++) {
    console.log(arreglo[i]);
}

// Preguntar posición y valor
readline.question("Inserte el índice donde desea agregar el valor (0-4): ", (posicion) => {
    readline.question("Inserte el valor que desea agregar: ", (valorAgregar) => {
        arreglo[parseInt(posicion)] = parseInt(valorAgregar);

        console.log("Arreglo después de la inserción:");
        for (let i = 0; i < arreglo.length; i++) {
            console.log(arreglo[i]);
        }

        // Preguntar elemento a buscar
        readline.question("Inserte el elemento que desea buscar: ", (elementoBuscar) => {
            let encontrado = false;
            for (let i = 0; i < arreglo.length; i++) {
                if (arreglo[i] === parseInt(elementoBuscar)) {
                    console.log(`Elemento ${elementoBuscar} encontrado en el índice ${i}`);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado) {
                console.log(`Elemento ${elementoBuscar} no encontrado en el arreglo`);
            }

            readline.close();
        });
    });
});

