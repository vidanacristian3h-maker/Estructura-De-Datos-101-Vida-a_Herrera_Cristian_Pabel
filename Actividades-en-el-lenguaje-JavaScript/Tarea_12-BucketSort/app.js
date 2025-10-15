function bucketSort(arr) {
  const n = arr.length;
  let buckets = Array.from({ length: n }, () => []);

  // Colocar cada número en su cubeta
  for (let num of arr) {
    let index = Math.floor(num * n);
    buckets[index].push(num);
  }

  // Ordenar cada cubeta
  for (let bucket of buckets) bucket.sort((a, b) => a - b);

  // Unir las cubetas
  return buckets.flat();
}

// Generar números aleatorios entre 0 y 1
let arr = Array.from({ length: 10 }, () => Math.random());

console.log("Antes:", arr);
arr = bucketSort(arr);
console.log("Después:", arr);
