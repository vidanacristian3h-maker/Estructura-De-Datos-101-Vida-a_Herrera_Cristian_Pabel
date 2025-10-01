function merge(arr, inicio, medio, fin) {
    let izquierda = arr.slice(inicio, medio + 1);
    let derecha = arr.slice(medio + 1, fin + 1);

    let i = 0, j = 0, k = inicio;

    while (i < izquierda.length && j < derecha.length) {
        if (izquierda[i] <= derecha[j]) arr[k++] = izquierda[i++];
        else arr[k++] = derecha[j++];
    }

    while (i < izquierda.length) arr[k++] = izquierda[i++];
    while (j < derecha.length) arr[k++] = derecha[j++];
}

function mergeSort(arr, inicio, fin) {
    if (inicio < fin) {
        let medio = Math.floor((inicio + fin) / 2);
        mergeSort(arr, inicio, medio);
        mergeSort(arr, medio + 1, fin);
        merge(arr, inicio, medio, fin);
    }
}

let n = 15;
let arr = Array.from({length: n}, () => Math.floor(Math.random() * 100));

console.log("Antes:", arr.join(" "));

mergeSort(arr, 0, arr.length - 1);

console.log("Despues:", arr.join(" "));
