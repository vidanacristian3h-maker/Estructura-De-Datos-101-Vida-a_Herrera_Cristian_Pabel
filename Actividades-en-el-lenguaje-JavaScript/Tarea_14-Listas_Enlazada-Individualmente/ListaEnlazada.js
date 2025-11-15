// 'readline' es un módulo integrado de Node.js para leer texto
const readline = require('readline');

//"interfaz" para leer y escribir en la consola
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

//Clases 
class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class LinkedList {
  constructor() {
    this.head = null;
  }

  append(data) {
    const newNode = new Node(data);
    if (this.head === null) {
      this.head = newNode;
      return;
    }
    let current = this.head;
    while (current.next !== null) {
      current = current.next;
    }
    current.next = newNode;
  }

  printList() {
    let current = this.head;
    let result = "HEAD -> ";
    while (current !== null) {
      result += `${current.data} -> `;
      current = current.next;
    }
    result += "NULL";
    console.log("\n--- Tu lista actual ---");
    console.log(result);
    console.log("------------------------\n");
  }
}

// la lista
const miLista = new LinkedList();

function preguntar() {

  // rl.question() hace la pregunta y espera la respuesta
  rl.question('Escribe un valor para agregar (o "salir" para terminar): ', (respuesta) => {
    
    // si quiere salir
    if (respuesta.toLowerCase() === 'salir') {
      console.log('¡Adiós! Lista final:');
      miLista.printList();
      rl.close(); // Cierra el programa
      return;
    }

    // Si no quiere salir, agregamos el dato a la lista
    miLista.append(respuesta);
    
    // Mostramos cómo va la lista
    miLista.printList();

    // llamamos a la función de nuevo para seguir preguntando
    preguntar();
  });
}

// Empezar el programa
console.log('--- Creador de Listas Enlazadas ---');
// Llamamos a la función por primera vez para iniciar el bucle
preguntar();