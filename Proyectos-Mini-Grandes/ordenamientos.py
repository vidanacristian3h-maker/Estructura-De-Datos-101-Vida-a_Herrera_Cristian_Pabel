# ordenamientos.py
import time
import sys
import random

# Evitar RecursionError (por si alguna función recursiva se usa)
sys.setrecursionlimit(30000)

# -------------------------
# Medición de tiempo
# -------------------------
def medir_tiempo_ms(func, arr):
    """
    Mide el tiempo en ms. Recibe func que modifica la lista in-place y arr (lista).
    Usamos arr.copy() dentro si se requiere; pero aquí el formulario hace la copia.
    """
    inicio = time.perf_counter()
    func(arr)
    fin = time.perf_counter()
    return (fin - inicio) * 1000.0

# -------------------------
# Util
# -------------------------
def generar_aleatorios(n, max_val=100000):
    return [random.randint(1, max_val) for _ in range(n)]

def medio_ordenado(arr):
    """Mitad ordenada, mitad aleatoria (como tu C#). Retorna nueva lista."""
    a = sorted(arr)
    mitad = len(a) // 2
    primera = a[:mitad]
    segunda = a[mitad:]
    random.shuffle(segunda)
    return primera + segunda

# -------------------------
# Algoritmos (manteniendo tu lógica)
# -------------------------
def burbuja(a):
    n = len(a)
    for i in range(n - 1):
        for j in range(n - i - 1):
            if a[j] > a[j + 1]:
                a[j], a[j + 1] = a[j + 1], a[j]

def insercion(a):
    for i in range(1, len(a)):
        key = a[i]
        j = i - 1
        while j >= 0 and a[j] > key:
            a[j + 1] = a[j]
            j -= 1
        a[j + 1] = key

def seleccion(a):
    n = len(a)
    for i in range(n - 1):
        min_idx = i
        for j in range(i + 1, n):
            if a[j] < a[min_idx]:
                min_idx = j
        a[i], a[min_idx] = a[min_idx], a[i]

# Partition usado por QuickSort
def partition(arr, low, high):
    pivot = arr[high]
    i = low - 1
    for j in range(low, high):
        if arr[j] <= pivot:
            i += 1
            arr[i], arr[j] = arr[j], arr[i]
    arr[i + 1], arr[high] = arr[high], arr[i + 1]
    return i + 1

def quick_sort_iterativo(arr):
    """QuickSort iterativo: estable y sin problemas de recursión."""
    n = len(arr)
    if n <= 1:
        return
    stack = [(0, n - 1)]
    while stack:
        low, high = stack.pop()
        if low < high:
            pi = partition(arr, low, high)
            if pi - 1 > low:
                stack.append((low, pi - 1))
            if pi + 1 < high:
                stack.append((pi + 1, high))

def merge_sort(a):
    if len(a) <= 1:
        return
    mid = len(a) // 2
    L = a[:mid]
    R = a[mid:]
    merge_sort(L)
    merge_sort(R)
    i = j = k = 0
    while i < len(L) and j < len(R):
        if L[i] < R[j]:
            a[k] = L[i]; i += 1
        else:
            a[k] = R[j]; j += 1
        k += 1
    while i < len(L):
        a[k] = L[i]; i += 1; k += 1
    while j < len(R):
        a[k] = R[j]; j += 1; k += 1

def heap_sort(a):
    n = len(a)
    def heapify(arr, n, i):
        largest = i
        l = 2 * i + 1
        r = 2 * i + 2
        if l < n and arr[l] > arr[largest]:
            largest = l
        if r < n and arr[r] > arr[largest]:
            largest = r
        if largest != i:
            arr[i], arr[largest] = arr[largest], arr[i]
            heapify(arr, n, largest)
    for i in range(n // 2 - 1, -1, -1):
        heapify(a, n, i)
    for i in range(n - 1, 0, -1):
        a[0], a[i] = a[i], a[0]
        heapify(a, i, 0)

def bucket_sort(a):
    n = len(a)
    if n == 0:
        return
    _max = max(a)
    _min = min(a)
    bucket_count = 10
    buckets = [[] for _ in range(bucket_count)]
    denom = (_max - _min + 1)
    for num in a:
        idx = int(((num - _min) / denom) * (bucket_count - 1))
        buckets[idx].append(num)
    idx = 0
    for b in buckets:
        b.sort()
        for num in b:
            a[idx] = num
            idx += 1

def radix_sort(a):
    if not a:
        return
    _max = max(a)
    exp = 1
    while _max // exp > 0:
        # counting sort by digit
        n = len(a)
        output = [0] * n
        count = [0] * 10
        for i in range(n):
            count[(a[i] // exp) % 10] += 1
        for i in range(1, 10):
            count[i] += count[i - 1]
        for i in range(n - 1, -1, -1):
            idx = (a[i] // exp) % 10
            output[count[idx] - 1] = a[i]
            count[idx] -= 1
        for i in range(n):
            a[i] = output[i]
        exp *= 10

# -------------------------
# Mapa útil para referenciar desde los formularios
# -------------------------
mapa_metodos = {
    "Burbuja": burbuja,
    "Inserción": insercion,
    "Selección": seleccion,
    "QuickSort": quick_sort_iterativo,
    "MergeSort": merge_sort,
    "HeapSort": heap_sort,
    "BucketSort": bucket_sort,
    "RadixSort": radix_sort
}

# expose random and helpers
rand = random
