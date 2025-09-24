const n = 10;
let numeros = [];

// Generar números aleatorios entre 1 y 100
for (let i = 0; i < n; i++) {
    numeros.push(Math.floor(Math.random() * 100) + 1);
}

console.log("Antes:", numeros.join(" "));

// ---------- Selection Sort ----------
for (let i = 0; i < n - 1; i++) {
    let posicionMenor = i;
    for (let j = i + 1; j < n; j++) {
        if (numeros[j] < numeros[posicionMenor]) {
            posicionMenor = j;
        }
    }
    // Intercambiar
    [numeros[i], numeros[posicionMenor]] = [numeros[posicionMenor], numeros[i]];
}

console.log("Después:", numeros.join(" "));
