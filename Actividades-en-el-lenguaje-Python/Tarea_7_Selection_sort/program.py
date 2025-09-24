import random

n = 10
numeros = [random.randint(1, 100) for _ in range(n)]

print("Antes:", numeros)

# ---------- Selection Sort ----------
for i in range(n - 1):
    posicion_menor = i
    for j in range(i + 1, n):
        if numeros[j] < numeros[posicion_menor]:
            posicion_menor = j
    # Intercambiar
    numeros[i], numeros[posicion_menor] = numeros[posicion_menor], numeros[i]

print("Después:", numeros)
