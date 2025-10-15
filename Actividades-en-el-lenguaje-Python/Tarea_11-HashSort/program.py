import random

# Generar arreglo aleatorio entre 0 y 50
arr = [random.randint(0, 50) for _ in range(10)]
print("Arreglo original:", arr)

# Crear diccionario (hash) para contar ocurrencias
hash_table = {}

for num in arr:
    hash_table[num] = hash_table.get(num, 0) + 1

# Reconstruir arreglo ordenado
sorted_arr = []
for key in sorted(hash_table.keys()):
    sorted_arr.extend([key] * hash_table[key])

print("Arreglo ordenado:", sorted_arr)
