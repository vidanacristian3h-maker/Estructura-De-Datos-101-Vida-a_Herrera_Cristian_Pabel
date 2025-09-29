import random

# Función QuickSort
def quick_sort(arr, inicio, fin):
    i, j = inicio, fin
    pivote = arr[(inicio + fin) // 2]  # pivote central

    while i <= j:
        while arr[i] < pivote:
            i += 1
        while arr[j] > pivote:
            j -= 1
        if i <= j:
            # intercambio
            arr[i], arr[j] = arr[j], arr[i]
            i += 1
            j -= 1

    # Recursión en las mitades
    if inicio < j:
        quick_sort(arr, inicio, j)
    if i < fin:
        quick_sort(arr, i, fin)

n = 15
# Generar lista aleatoria
arr = [random.randint(0, 99) for _ in range(n)]

print("Antes:", arr)

quick_sort(arr, 0, len(arr) - 1)

print("Despues:", arr)
