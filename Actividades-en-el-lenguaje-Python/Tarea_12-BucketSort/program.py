import random

def bucket_sort(arr):
    n = len(arr)
    buckets = [[] for _ in range(n)]

    # Colocar cada número en su cubeta
    for num in arr:
        index = int(num * n)
        buckets[index].append(num)

    # Ordenar cada cubeta
    for bucket in buckets:
        bucket.sort()

    # Unir cubetas en un solo arreglo
    sorted_arr = []
    for bucket in buckets:
        sorted_arr.extend(bucket)
    return sorted_arr

# Generar números aleatorios entre 0 y 1
arr = [random.random() for _ in range(10)]

print("Antes:", arr)
arr = bucket_sort(arr)
print("\nDespués:", arr)
