let n = 10;
let numeros = Array.from({ length: n }, () => Math.floor(Math.random() * 100) + 1);

console.log("Antes:", numeros);

// Bubble Sort
let swapped;
do {
    swapped = false;
    for (let i = 0; i < numeros.length - 1; i++) {
        if (numeros[i] > numeros[i + 1]) {
            let temp = numeros[i];
            numeros[i] = numeros[i + 1];
            numeros[i + 1] = temp;
            swapped = true;
        }
    }
} while (swapped);

console.log("Después:", numeros);
