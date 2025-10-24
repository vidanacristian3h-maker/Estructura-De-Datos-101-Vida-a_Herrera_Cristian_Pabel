#Programa Sudoku juego completo
#Nombre: Cristian Pabel Vidaña Herrera
#Grupo 201
#Ingenieria en software
#Materia Estructura de datos

import random
import os

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

# --- 3. Bucle Principal del Juego ---

def jugar_sudoku_simple():
    """Función principal del juego."""
    clear_screen() # Limpieza inicial
    
    tablero = generar_tablero(celdas_a_mantener=30)
    tablero_inicial = [fila[:] for fila in tablero]
    
    while encontrar_vacio(tablero) is not None:
        imprimir_tablero(tablero)

        entrada = input("Juega (ej: 1,5,9), borra (ej: 1,5,0), o escribe 's' para salir: ")
        
        if entrada.lower() == 's':
            print("¡Gracias por jugar!")
            return

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
                tablero[r][c] = 0
                continue

            # 4. Validar reglas del Sudoku (solo para números 1-9)
            if es_valido(tablero, r, c, numero):
                tablero[r][c] = numero
            else:
                print("Movimiento inválido: El número ya existe en esa fila, columna o caja.")
                input("Presiona Enter para continuar...")
        
        except ValueError:
            print("Error de formato. Usa fila,columna,número (ej: 1,5,9).")
            input("Presiona Enter para continuar...")
            
        except IndexError:
            print("Error: Posición o formato incorrecto.")
            input("Presiona Enter para continuar...")

    # Tablero completo
    imprimir_tablero(tablero)
    print("\n¡FELICIDADES! Has completado el Sudoku. 🎉")

if __name__ == "__main__":
    jugar_sudoku_simple()