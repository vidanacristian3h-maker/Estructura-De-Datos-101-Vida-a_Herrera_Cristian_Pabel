import random

# Función para ajustar el heap
def heapify(arr, n, i):
    mayor = i          # Se asume que la raíz es la mayor
    izq = 2 * i + 1    # Hijo izquierdo
    der = 2 * i + 2    # Hijo derecho

    # Si el hijo izquierdo es mayor que la raíz
    if izq < n and arr[izq] > arr[mayor]:
        mayor = izq
    # Si el hijo derecho es mayor que el mayor actual
    if der < n and arr[der] > arr[mayor]:
        mayor = der

    # Si el mayor no es la raíz, intercambiar y seguir ajustando
    if mayor != i:
        arr[i], arr[mayor] = arr[mayor], arr[i]
        heapify(arr, n, mayor)

# Ordenamiento Heap Sort
def heap_sort(arr):
    n = len(arr)
    # 1️⃣ Construir un heap máximo
    for i in range(n // 2 - 1, -1, -1):
        heapify(arr, n, i)
    # 2️⃣ Extraer los elementos del heap
    for i in range(n - 1, 0, -1):
        arr[i], arr[0] = arr[0], arr[i]
        heapify(arr, i, 0)

# Generar arreglo aleatorio de 10 elementos
arr = [random.randint(1, 100) for _ in range(10)]

print("Arreglo original:", arr)
heap_sort(arr)
print("Arreglo ordenado:", arr)
