import random

# Mezclar dos mitades ordenadas
def merge(arr, inicio, medio, fin):
    izquierda = arr[inicio:medio+1]
    derecha = arr[medio+1:fin+1]

    i = j = 0
    k = inicio

    while i < len(izquierda) and j < len(derecha):
        if izquierda[i] <= derecha[j]:
            arr[k] = izquierda[i]
            i += 1
        else:
            arr[k] = derecha[j]
            j += 1
        k += 1

    while i < len(izquierda):
        arr[k] = izquierda[i]
        i += 1
        k += 1

    while j < len(derecha):
        arr[k] = derecha[j]
        j += 1
        k += 1

# MergeSort recursivo
def merge_sort(arr, inicio, fin):
    if inicio < fin:
        medio = (inicio + fin) // 2
        merge_sort(arr, inicio, medio)
        merge_sort(arr, medio + 1, fin)
        merge(arr, inicio, medio, fin)

n = 15
arr = [random.randint(0, 99) for _ in range(n)]

print("Antes:", arr)

merge_sort(arr, 0, len(arr) - 1)

print("Despues:", arr)
