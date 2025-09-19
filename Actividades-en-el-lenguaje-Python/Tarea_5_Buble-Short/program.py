import random

n = 10
numeros = [random.randint(1, 100) for _ in range(n)]

print("Antes:", numeros)

# Bubble Sort
swapped = True
while swapped:
    swapped = False
    for i in range(len(numeros) - 1):
        if numeros[i] > numeros[i + 1]:
            numeros[i], numeros[i + 1] = numeros[i + 1], numeros[i]
            swapped = True

print("Después:", numeros)
