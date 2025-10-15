// Generar arreglo con números aleatorios entre 0 y 50
let arr = Array.from({ length: 10 }, () => Math.floor(Math.random() * 51));

console.log("Arreglo original:", arr);

// Crear un objeto como tabla hash
let hash = {};

// Contar ocurrencias de cada número
for (let num of arr) {
    if (hash[num]) hash[num]++;
    else hash[num] = 1;
}

// Reconstruir el arreglo ordenado
let sortedArr = [];
Object.keys(hash).sort((a, b) => a - b).forEach(key => {
    for (let i = 0; i < hash[key]; i++)
        sortedArr.push(parseInt(key));
});

console.log("Arreglo ordenado:", sortedArr);
