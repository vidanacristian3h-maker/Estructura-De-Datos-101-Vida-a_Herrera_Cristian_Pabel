import random

def obtener_max(arr):
    return max(arr)

def contar_orden(arr, exp):
    n = len(arr)
    salida = [0] * n
    conteo = [0] * 10

    for i in range(n):
        indice = (arr[i] // exp) % 10
        conteo[indice] += 1

    for i in range(1, 10):
        conteo[i] += conteo[i - 1]

    for i in range(n - 1, -1, -1):
        indice = (arr[i] // exp) % 10
        salida[conteo[indice] - 1] = arr[i]
        conteo[indice] -= 1

    for i in range(n):
        arr[i] = salida[i]

def radix_sort(arr):
    maximo = obtener_max(arr)
    exp = 1
    while maximo // exp > 0:
        contar_orden(arr, exp)
        exp *= 10

arr = [random.randint(0, 999) for _ in range(15)]
print("Antes:", arr)
radix_sort(arr)
print("Despues:", arr)
