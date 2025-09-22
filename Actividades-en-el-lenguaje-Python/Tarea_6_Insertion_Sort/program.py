import random

n = 10
numeros = [random.randint(1, 100) for _ in range(n)]

print("Antes:", numeros)

# Insertion Sort
for i in range(1, len(numeros)):
    clave = numeros[i]
    j = i - 1

    while j >= 0 and numeros[j] > clave:
        numeros[j + 1] = numeros[j]
        j -= 1

    numeros[j + 1] = clave

print("Después:", numeros)
