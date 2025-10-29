# Programa Sudoku juego completo con guardado de partida
# Nombre: Cristian Pabel Vidaña Herrera
# Grupo 201
# Ingeniería en Software
# Materia: Estructura de Datos

import random
import os
import json
import copy

# --- 1. Utilidades ---

def clear_screen():
    """Limpia la consola."""
    os.system('cls' if os.name == 'nt' else 'clear')

def guardar_partida(datos):
    """Guarda la partida en un archivo JSON."""
    with open("partida_guardada.txt", "w") as archivo:
        json.dump(datos, archivo)

def cargar_partida():
    """Carga una partida guardada si existe."""
    if os.path.exists("partida_guardada.txt"):
        with open("partida_guardada.txt", "r") as archivo:
            try:
                return json.load(archivo)
            except json.JSONDecodeError:
                return None
    return None

def borrar_partida():
    """Elimina el archivo de guardado."""
    if os.path.exists("partida_guardada.txt"):
        os.remove("partida_guardada.txt")

# --- 2. Tablero y validaciones ---

def imprimir_tablero(tablero):
    clear_screen()
    print("=== Sudoku ===\n")
    print("\n  1 2 3   4 5 6   7 8 9")
    print(" +-------+-------+-------+")
    for i in range(9):
        fila_str = f"{i+1}| "
        for j in range(9):
            valor = tablero[i][j] if tablero[i][j] != 0 else '.'
            fila_str += f"{valor} "
            if (j + 1) % 3 == 0 and j < 8:
                fila_str += "| "
        print(fila_str)
        if (i + 1) % 3 == 0 and i < 8:
            print(" +-------+-------+-------+")
    print(" +-------+-------+-------+\n")

def es_valido(tablero, fila, columna, numero):
    for i in range(9):
        if tablero[fila][i] == numero or tablero[i][columna] == numero:
            return False
    inicio_fila, inicio_columna = (fila // 3) * 3, (columna // 3) * 3
    for i in range(3):
        for j in range(3):
            if tablero[inicio_fila + i][inicio_columna + j] == numero:
                return False
    return True

def encontrar_vacio(tablero):
    for i in range(9):
        for j in range(9):
            if tablero[i][j] == 0:
                return (i, j)
    return None

def resolver_sudoku(tablero):
    vacio = encontrar_vacio(tablero)
    if not vacio:
        return True
    fila, columna = vacio
    for numero in range(1, 10):
        if es_valido(tablero, fila, columna, numero):
            tablero[fila][columna] = numero
            if resolver_sudoku(tablero):
                return True
            tablero[fila][columna] = 0
    return False

# --- 3. Generación del tablero ---

def generar_tablero(celdas_a_mantener):
    tablero = [[0 for _ in range(9)] for _ in range(9)]
    resolver_sudoku(tablero)
    puzzle = [fila[:] for fila in tablero]
    celdas_a_remover = 81 - celdas_a_mantener
    while celdas_a_remover > 0:
        fila = random.randint(0, 8)
        columna = random.randint(0, 8)
        if puzzle[fila][columna] != 0:
            puzzle[fila][columna] = 0
            celdas_a_remover -= 1
    return puzzle

# --- 4. Juego con vidas y puntuación ---

MAX_VIDAS = 5

def jugar_un_puzzle(tablero, tablero_inicial, nivel_actual, puzzle_actual, puntuacion):
    vidas = MAX_VIDAS
    tablero_actual = [fila[:] for fila in tablero]

    while True:
        if encontrar_vacio(tablero_actual) is None:
            imprimir_tablero(tablero_actual)
            print("\n¡FELICIDADES! Has completado este Sudoku 🎉")
            print(f"Vidas restantes: {vidas}  →  +{vidas} puntos")
            puntuacion += vidas
            input("Presiona Enter para continuar...")
            return True, puntuacion

        imprimir_tablero(tablero_actual)
        print(f"Nivel: {nivel_actual+1} | Puzzle: {puzzle_actual+1}/5 | Vidas: {vidas} | Puntuación: {puntuacion}")
        entrada = input("Juega (1,5,9), borra (1,5,0), 'r' reinicia, 's' salir y guardar: ")

        if entrada.lower() == 's':
            datos = {
                "nivel_actual": nivel_actual,
                "puzzle_actual": puzzle_actual,
                "vidas": vidas,
                "puntuacion": puntuacion,
                "tablero": tablero_actual,
                "tablero_inicial": tablero_inicial
            }
            guardar_partida(datos)
            print("Partida guardada con éxito. 👌")
            input("Presiona Enter para salir...")
            return False, puntuacion

        if entrada.lower() == 'r':
            tablero_actual = [fila[:] for fila in tablero_inicial]
            vidas = MAX_VIDAS
            print("Puzzle reiniciado.")
            input("Presiona Enter para continuar...")
            continue

        try:
            fila, columna, numero = map(int, entrada.split(','))
            r, c = fila - 1, columna - 1
            if not (1 <= fila <= 9 and 1 <= columna <= 9 and 0 <= numero <= 9):
                print("Error: Valores fuera de rango (1-9).")
                input("Enter para continuar...")
                continue

            if tablero_inicial[r][c] != 0:
                print("No puedes cambiar una celda original.")
                input("Enter para continuar...")
                continue

            if numero == 0:
                tablero_actual[r][c] = 0
                continue

            if es_valido(tablero_actual, r, c, numero):
                tablero_actual[r][c] = numero
            else:
                vidas -= 1
                print("Movimiento inválido ❌ -1 vida")
                if vidas <= 0:
                    print("Te quedaste sin vidas. Puzzle reiniciado.")
                    tablero_actual = [fila[:] for fila in tablero_inicial]
                    vidas = MAX_VIDAS
                input("Enter para continuar...")
        except:
            print("Formato inválido. Usa: fila,columna,número")
            input("Enter para continuar...")

# --- 5. Niveles y flujo del juego ---

DIFICULTADES = [
    ("Muy Fácil", 36, 44),
    ("Fácil", 32, 35),
    ("Medio", 28, 31),
    ("Difícil", 24, 27),
    ("Muy Difícil", 17, 23)
]

def generar_puzzles_por_nivel():
    niveles = []
    for nombre, min_mant, max_mant in DIFICULTADES:
        puzzles = []
        for _ in range(5):
            celdas = random.randint(min_mant, max_mant)
            puzzles.append(generar_tablero(celdas))
        niveles.append((nombre, puzzles))
    return niveles

def jugar_todos_los_niveles():
    clear_screen()
    partida = cargar_partida()

    if partida:
        print("Se detectó una partida guardada.")
        opcion = input("¿Deseas continuar desde donde quedaste? (s/n): ").lower()
        if opcion != 's':
            borrar_partida()
            partida = None

    niveles = generar_puzzles_por_nivel()
    puntuacion = 0
    nivel_inicio = 0
    puzzle_inicio = 0
    vidas_guardadas = MAX_VIDAS

    if partida:
        nivel_inicio = partida["nivel_actual"]
        puzzle_inicio = partida["puzzle_actual"]
        puntuacion = partida["puntuacion"]
        vidas_guardadas = partida["vidas"]
        tablero_guardado = partida["tablero"]
        tablero_inicial_guardado = partida["tablero_inicial"]

    for n_idx, (nombre, puzzles) in enumerate(niveles[nivel_inicio:], start=nivel_inicio):
        for p_idx, puzzle in enumerate(puzzles[puzzle_inicio:] if n_idx == nivel_inicio else puzzles, start=puzzle_inicio if n_idx == nivel_inicio else 0):
            clear_screen()
            print(f"Nivel {n_idx+1}/5 - {nombre} | Puzzle {p_idx+1}/5")
            input("Presiona Enter para comenzar...")

            tablero = [fila[:] for fila in puzzle]
            tablero_inicial = [fila[:] for fila in puzzle]

            # Si hay una partida guardada, continuar desde ese tablero
            if partida and n_idx == nivel_inicio and p_idx == puzzle_inicio:
                tablero = tablero_guardado
                tablero_inicial = tablero_inicial_guardado
                partida = None

            resultado, puntuacion = jugar_un_puzzle(tablero, tablero_inicial, n_idx, p_idx, puntuacion)
            if not resultado:
                return  # jugador salió

        puzzle_inicio = 0  # reset al completar el nivel
        clear_screen()
        print(f"¡Nivel {n_idx+1} completado! Puntuación actual: {puntuacion}")
        input("Presiona Enter para continuar...")

    borrar_partida()
    clear_screen()
    print(f"🏆 ¡FELICIDADES! Has completado todos los niveles con {puntuacion} puntos totales.")
    input("Presiona Enter para salir...")

# --- 6. Punto de entrada ---

if __name__ == "__main__":
    jugar_todos_los_niveles()
