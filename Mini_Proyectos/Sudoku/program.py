# Programa Sudoku juego completo
# Nombre: Cristian Pabel Vidaña Herrera
# Grupo 201
# Ingenieria en software
# Materia Estructura de datos

import random
import os
import copy

# --- 1. Utilidades ---

def clear_screen():
    """Limpia la consola."""
    os.system('cls' if os.name == 'nt' else 'clear')

# -----------------------

def imprimir_tablero(tablero):
    """Muestra el tablero de Sudoku en la consola con formato."""
    clear_screen() # Usamos la función de limpieza centralizada
    
    print("Bienvenido al juego de Sudoku!\n")
    print("\n  1 2 3   4 5 6   7 8 9")
    print(" +-------+-------+-------+")
    for i in range(9):
        fila_str = f"{i+1}| "
        for j in range(9):
            # Muestra '.' para celdas vacías (0), el número si no está vacío
            valor = tablero[i][j] if tablero[i][j] != 0 else '.'
            fila_str += f"{valor} "
            if (j + 1) % 3 == 0 and j < 8:
                fila_str += "| " # Separador de cajas 3x3
        print(fila_str)
        if (i + 1) % 3 == 0 and i < 8:
            print(" +-------+-------+-------+") # Separador de cajas 3x3
    print(" +-------+-------+-------+\n")

def es_valido(tablero, fila, columna, numero):
    """Verifica si un número es legal en la posición dada."""
    # 1. Chequeo de Fila y Columna
    for i in range(9):
        # Si el número ya está en la fila o columna, es inválido
        if tablero[fila][i] == numero or tablero[i][columna] == numero:
            return False

    # 2. Chequeo de la Caja 3x3
    inicio_fila = (fila // 3) * 3
    inicio_columna = (columna // 3) * 3
    for i in range(3):
        for j in range(3):
            if tablero[inicio_fila + i][inicio_columna + j] == numero:
                return False

    return True

def encontrar_vacio(tablero):
    """Encuentra la primera celda vacía (con valor 0)."""
    for i in range(9):
        for j in range(9):
            if tablero[i][j] == 0:
                return (i, j)  # Retorna (fila, columna)
    return None

def resolver_sudoku(tablero):
    """Algoritmo de Backtracking para resolver el Sudoku."""
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

# --- 2. Generación del Tablero ---

def generar_tablero(celdas_a_mantener):
    """Genera un Sudoku completo y luego remueve celdas."""
    
    tablero = [[0 for _ in range(9)] for _ in range(9)]
    resolver_sudoku(tablero)
    puzle = [fila[:] for fila in tablero] 
    celdas_a_remover = 81 - celdas_a_mantener
    
    while celdas_a_remover > 0:
        fila = random.randint(0, 8)
        columna = random.randint(0, 8)
        
        if puzle[fila][columna] != 0:
            puzle[fila][columna] = 0 
            celdas_a_remover -= 1
            
    return puzle

# --- 3. Juego por puzzle con vidas ---

MAX_VIDAS = 5

def jugar_un_puzzle(tablero, tablero_inicial):
    """
    Juega un puzzle individual. Devuelve True si se completa,
    o False si el jugador decide salir (opción 's' en el input principal).
    Las vidas se restablecen si se llega a 0, y el puzzle se reinicia preservando
    los puzzles completados anteriormente (no se pierde progreso).
    """
    vidas = MAX_VIDAS
    tablero_actual = [fila[:] for fila in tablero]  # copia para jugar
    while True:
        if encontrar_vacio(tablero_actual) is None:
            imprimir_tablero(tablero_actual)
            print("\n¡FELICIDADES! Has completado este Sudoku. 🎉")
            input("Presiona Enter para continuar...")
            return True  # puzzle completado

        imprimir_tablero(tablero_actual)
        print(f"Vidas restantes: {vidas}")
        entrada = input("Juega (ej: 1,5,9), borra (ej: 1,5,0), escribe 'r' para reiniciar puzzle, o 's' para salir: ")
        
        if entrada.lower() == 's':
            print("Saliendo del juego...") 
            return False

        if entrada.lower() == 'r':
            # Reinicia puzzle actual a su estado inicial (no se pierde progreso previo)
            tablero_actual = [fila[:] for fila in tablero_inicial]
            vidas = MAX_VIDAS
            print("Puzzle reiniciado. Vidas restauradas.")
            input("Presiona Enter para continuar...")
            continue

        try:
            fila, columna, numero = map(int, entrada.split(','))
            r, c = fila - 1, columna - 1 

            # 1. Validar rangos (fila/columna 1-9, número 0-9)
            if not (1 <= fila <= 9 and 1 <= columna <= 9 and 0 <= numero <= 9):
                print("Error: Fila/Columna deben ser 1-9, el número debe ser 0-9.")
                input("Presiona Enter para continuar...")
                continue

            # 2. VALIDACIÓN CLAVE: Evita modificar celdas originales
            if tablero_inicial[r][c] != 0:
                print("Error: No puedes cambiar un número original del puzle.")
                input("Presiona Enter para continuar...")
                continue

            # 3. Borrar número (si el número es 0)
            if numero == 0:
                tablero_actual[r][c] = 0
                continue

            # 4. Validar reglas del Sudoku (solo para números 1-9)
            if es_valido(tablero_actual, r, c, numero):
                tablero_actual[r][c] = numero
            else:
                vidas -= 1
                print(f"Movimiento inválido: El número ya existe en esa fila, columna o caja. -1 vida")
                if vidas > 0:
                    input("Presiona Enter para continuar...")
                else:
                    # Se quedaron sin vidas: reiniciamos el puzzle pero no el progreso del nivel
                    print("\nTe quedaste sin vidas en este puzzle.")
                    print("No pierdes el progreso del nivel; el puzzle se reiniciará y tus vidas se restaurarán.")
                    input("Presiona Enter para reiniciar este puzzle...")
                    tablero_actual = [fila[:] for fila in tablero_inicial]
                    vidas = MAX_VIDAS
        except ValueError:
            print("Error de formato. Usa fila,columna,número (ej: 1,5,9).")
            input("Presiona Enter para continuar...")
        except IndexError:
            print("Error: Posición o formato incorrecto.")
            input("Presiona Enter para continuar...")

# --- 4. Sistema de niveles y flujo del juego ---

# Mapeo de dificultad a rango de celdas a mantener
DIFICULTADES = [
    ("Muy Fácil", 36, 44),
    ("Fácil", 32, 35),
    ("Medio", 28, 31),
    ("Difícil", 24, 27),
    ("Muy Difícil", 17, 23)
]

def generar_puzzles_por_nivel():
    """
    Genera las 5 puzzles por cada nivel con celdas aleatorias en el rango dado.
    Retorna una lista de niveles, cada nivel es una lista de 5 tableros.
    """
    niveles = []
    for nombre, min_mantener, max_mantener in DIFICULTADES:
        puzzles = []
        for _ in range(5):  # 5 sudokus por nivel
            celdas = random.randint(min_mantener, max_mantener)
            puzzle = generar_tablero(celdas_a_mantener=celdas)
            puzzles.append(puzzle)
        niveles.append((nombre, puzzles))
    return niveles

def jugar_todos_los_niveles():
    """Orquestador de los 5 niveles x 5 puzzles cada uno."""
    clear_screen()
    print("==== Sudoku: Carrera de Niveles ====")
    print("Reglas clave:")
    print(f"- Cada puzzle tiene {MAX_VIDAS} vidas. Cada movimiento inválido quita 1 vida.")
    print("- Si te quedas sin vidas en un puzzle, el puzzle se reinicia pero no pierdes el progreso de los puzzles ya completados.")
    print("- Completa 5 puzzles para pasar al siguiente nivel. Hay 5 niveles (25 puzzles en total).")
    input("\nPresiona Enter para generar los puzzles y comenzar...")

    niveles = generar_puzzles_por_nivel()

    # Recorrer niveles
    for idx_nivel, (nombre_nivel, puzzles) in enumerate(niveles, start=1):
        for idx_puzzle, puzzle in enumerate(puzzles, start=1):
            # tablero y su copia inicial para proteger celdas originales
            tablero = [fila[:] for fila in puzzle]
            tablero_inicial = [fila[:] for fila in puzzle]

            # Mensaje de nivel/puzzle
            clear_screen()
            print(f"Nivel {idx_nivel}/5 - {nombre_nivel} | Puzzle {idx_puzzle}/5")
            print("Recuerda: 'r' reinicia este puzzle, 's' sale del juego.")
            input("Presiona Enter para empezar este puzzle...")

            resultado = jugar_un_puzzle(tablero, tablero_inicial)
            if not resultado:
                # El usuario eligió salir ('s')
                print("Has salido del juego. Gracias por jugar.")
                return

            # Si completó el puzzle, continuar al siguiente
            # (el juego no "pierde" el progreso en caso de reinicio por vidas)
        # Nivel completado
        clear_screen()
        print(f"¡Has completado el nivel {idx_nivel} - {nombre_nivel}! 🎉")
        if idx_nivel < len(niveles):
            input("Presiona Enter para pasar al siguiente nivel...")
    # Todos los niveles completados
    clear_screen()
    print("¡FELICIDADES! Has completado los 25 puzzles (5 niveles). 🏆")
    input("Presiona Enter para terminar...")

# --- 5. Punto de entrada ---

if __name__ == "__main__":
    jugar_todos_los_niveles()
