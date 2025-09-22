let n = 10;
let numeros = Array.from({ length: n }, () => Math.floor(Math.random() * 100) + 1);

console.log("Antes:", numeros);

// Insertion Sort
for (let i = 1; i < numeros.length; i++) {
    let clave = numeros[i];
    let j = i - 1;

    while (j >= 0 && numeros[j] > clave) {
        numeros[j + 1] = numeros[j];
        j--;
    }
    numeros[j + 1] = clave;
}

console.log("Después:", numeros);
