function quickSort(arr, inicio, fin) {
    let i = inicio, j = fin;
    let pivote = arr[Math.floor((inicio + fin) / 2)]; // pivote central

    while (i <= j) {
        while (arr[i] < pivote) i++; // mover izquierda
        while (arr[j] > pivote) j--; // mover derecha

        if (i <= j) {
            // intercambio
            let temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++; j--;
        }
    }

    // Recursión
    if (inicio < j) quickSort(arr, inicio, j);
    if (i < fin) quickSort(arr, i, fin);
}

let n = 15;
// Generar arreglo aleatorio
let arr = Array.from({length: n}, () => Math.floor(Math.random() * 100));

console.log("Antes:", arr.join(" "));

// Ordenar
quickSort(arr, 0, arr.length - 1);

console.log("Despues:", arr.join(" "));
