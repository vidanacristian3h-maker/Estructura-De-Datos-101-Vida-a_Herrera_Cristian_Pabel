function obtenerMax(arr) {
  return Math.max(...arr);
}

function contarOrden(arr, exp) {
  let salida = new Array(arr.length).fill(0);
  let conteo = new Array(10).fill(0);

  for (let i = 0; i < arr.length; i++)
    conteo[Math.floor(arr[i] / exp) % 10]++;

  for (let i = 1; i < 10; i++)
    conteo[i] += conteo[i - 1];

  for (let i = arr.length - 1; i >= 0; i--) {
    salida[conteo[Math.floor(arr[i] / exp) % 10] - 1] = arr[i];
    conteo[Math.floor(arr[i] / exp) % 10]--;
  }

  for (let i = 0; i < arr.length; i++)
    arr[i] = salida[i];
}

function radixSort(arr) {
  let max = obtenerMax(arr);
  for (let exp = 1; Math.floor(max / exp) > 0; exp *= 10)
    contarOrden(arr, exp);
}

let arr = Array.from({ length: 15 }, () => Math.floor(Math.random() * 1000));

console.log("Antes:", arr.join(" "));
radixSort(arr);
console.log("Despues:", arr.join(" "));
