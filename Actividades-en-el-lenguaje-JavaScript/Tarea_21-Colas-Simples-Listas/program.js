class Nodo {
    constructor(dato) {
        this.dato = dato;
        this.siguiente = null;
    }
}

let front = null;
let rear = null;

function insertar() {
    let elemento = Number(prompt("Ingrese el elemento:"));
    let nuevo = new Nodo(elemento);

    if (front === null && rear === null) {
        front = rear = nuevo;
    } else {
        rear.siguiente = nuevo;
        rear = nuevo;
    }

    alert("Elemento insertado correctamente.");
}

function eliminar() {
    if (front === null) {
        alert("SUBDESBORDAMIENTO (UNDERFLOW)");
        return;
    }

    let elemento = front.dato;

    if (front === rear) {
        front = rear = null;
    } else {
        front = front.siguiente;
    }

    alert("Elemento eliminado: " + elemento);
}

function mostrar() {
    if (front === null) {
        alert("La cola está vacía.");
        return;
    }

    let temp = front;
    let salida = "Elementos en la cola:\n";

    while (temp !== null) {
        salida += temp.dato + "\n";
        temp = temp.siguiente;
    }

    alert(salida);
}

function menu() {
    let opcion = 0;

    while (opcion != 4) {
        opcion = Number(prompt(
            "1. Insertar un elemento\n" +
            "2. Eliminar un elemento\n" +
            "3. Mostrar la cola\n" +
            "4. Salir"
        ));

        switch (opcion) {
            case 1: insertar(); break;
            case 2: eliminar(); break;
            case 3: mostrar(); break;
            case 4: alert("Saliendo..."); break;
            default: alert("Opción inválida.");
        }
    }
}

menu();
