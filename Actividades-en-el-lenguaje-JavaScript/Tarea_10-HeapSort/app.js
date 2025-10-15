// Función para ajustar el heap
function heapify(arr, n, i) {
    let mayor = i;        // Se asume que la raíz es la mayor
    let izq = 2 * i + 1;  // Hijo izquierdo
    let der = 2 * i + 2;  // Hijo derecho

    if (izq < n && arr[izq] > arr[mayor])
        mayor = izq;
    if (der < n && arr[der] > arr[mayor])
        mayor = der;

    // Si el mayor no es la raíz, intercambiar y seguir ajustando
    if (mayor !== i) {
        [arr[i], arr[mayor]] = [arr[mayor], arr[i]];
        heapify(arr, n, mayor);
    }
}

// Ordenamiento Heap Sort
function heapSort(arr) {
    let n = arr.length;

    // 1️⃣ Construir el heap
    for (let i = Math.floor(n / 2) - 1; i >= 0; i--)
        heapify(arr, n, i);

    // 2️⃣ Extraer elementos del heap
    for (let i = n - 1; i > 0; i--) {
        [arr[0], arr[i]] = [arr[i], arr[0]];
        heapify(arr, i, 0);
    }
}

// Generar arreglo con números aleatorios del 1 al 100
let arr = Array.from({ length: 10 }, () => Math.floor(Math.random() * 100) + 1);

console.log("Arreglo original:", arr);
heapSort(arr);
console.log("Arreglo ordenado:", arr);
