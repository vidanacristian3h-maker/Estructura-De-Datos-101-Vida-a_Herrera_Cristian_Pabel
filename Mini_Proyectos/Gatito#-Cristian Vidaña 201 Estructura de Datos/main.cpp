#include <iostream>
using namespace std;

// ---------- FUNCIONES AUXILIARES ----------

// Mostrar tablero visual
void MostrarTablero(char tablero[3][3]) {
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            cout << tablero[i][j];
            if (j < 2) cout << " | ";
        }
        cout << "\n";
        if (i < 2) cout << "--+---+--\n";
    }
}

// Verificar ganador usando la matriz numérica
// Devuelve 1 si X ganó, -1 si O ganó, 0 si nadie
int VerificarGanador(int t[3][3]) {


    // Revisar filas y columnas
    for (int i = 0; i < 3; i++) {
        int fila = t[i][0] + t[i][1] + t[i][2];
        int col  = t[0][i] + t[1][i] + t[2][i];
        if (fila == 3 || col == 3) return 1;   // X gana
        if (fila == -3 || col == -3) return -1; // O gana

    }


    // Revisar diagonales
    int diag1 = t[0][0] + t[1][1] + t[2][2];
    int diag2 = t[0][2] + t[1][1] + t[2][0];
    if (diag1 == 3 || diag2 == 3) return 1;
    if (diag1 == -3 || diag2 == -3) return -1;


    return 0; // nadie ganó
}



// Verificar si hay empate
bool Empate(int t[3][3]) {
    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (t[i][j] == 0) return false; // todavía hay casillas libres
    return true;
}




// ---------- PROGRAMA PRINCIPAL ----------
int main() {


    // Tablero visual para mostrar al jugador
    char tablero[3][3] = { {' ',' ',' '}, {' ',' ',' '}, {' ',' ',' '} };

    // Tablero numérico para lógica de sumas
    int tableroNum[3][3] = { {0,0,0}, {0,0,0}, {0,0,0} };


    //-----Codigo del PROGRAMA-----
    cout << "####  EL GATITO  ####                            --Version 0.1--\n";
    cout << "Elige del 1 al 9 para colocar tu ficha.\n";
    cout << "Numeracion de ejemplo:\n";
    int GatitoNumerico[3][3] = {{1,2,3},{4,5,6},{7,8,9}};
    for(int i=0;i<3;i++){
        for(int j=0;j<3;j++){
            cout << GatitoNumerico[i][j];
            if(j<2) cout << " | ";
        }
        cout << "\n";
        if(i<2) cout << "--+---+--\n";
    }



    // Preguntar si iniciar juego
    char Decision;
    bool DecisionEnBool=false;
    do {
        cout << "Empezar juego (y/n): ";
        cin >> Decision;
        if(Decision=='y') DecisionEnBool = true;
    } while(DecisionEnBool==false);



    //DECLARACION ANTES DE INICIAR
    bool JuegoTerminado=false;
    char jugadorActual='X'; // empieza jugador X

    //-----------COMIENZA EL JUEGO-----------
    do {
        int NumeroACambiar;
        cout << "\nTurno del jugador '" << jugadorActual << "': (elige del 1 al 9)\n"; //ELIGE CUAL POSICION DEL ARREGLO QUIERE PONER SI SIMBOLO
        MostrarTablero(tablero); //SE VA A UNA FUNCTION PARA DAR EL GATITO ACTUAL

        cout << "Posicion: ";
        cin >> NumeroACambiar;

        // SE REVISA SI EL NUMERO PUESTO SI ESTA EN EL ARREGLO
        if(NumeroACambiar<1 || NumeroACambiar>9){
            cout << "Posicion invalida, intenta de nuevo.\n";
            continue;
        }



        // Convertir número a coordenadas
        int fila = (NumeroACambiar-1)/3;   //EJEMPLO SI PONES 5 dara 1 por sera (5-1 = 4/3 = 1 por divisiones en enteros)
        int columna = (NumeroACambiar-1)%3; //EJEMPLO SI PONES 5 dara 1 por (5-1 = 4 % 3 residuo de esa division es 1)



        // Verificar si la casilla está libre
        if(tablero[fila][columna]!=' '){
            cout << "Casilla ocupada, intenta otra.\n";
            continue;
        }




        // Colocar ficha en ambos tableros
        tablero[fila][columna] = jugadorActual; // pone ficha en simbolos y para ahorra el trabajo de escribirlo ponemos el simbolo del jugador
        tableroNum[fila][columna] = (jugadorActual=='X') ? 1 : -1; //Este es para el arreglo GatitoNum Pondra numero en vez de simbolos




        // Verificar ganador usando la matriz numérica
        int resultado = VerificarGanador(tableroNum);

        //compara si el resultado es 1 y si es entonces gano X
        if(resultado==1){
            MostrarTablero(tablero);
            cout << "\n¡El jugador 'X' ha ganado!\n";
            JuegoTerminado=true;

            // compara si es -1 y si es entonces gano O
        } else if(resultado==-1){
            MostrarTablero(tablero);
            cout << "\n¡El jugador 'O' ha ganado!\n";
            JuegoTerminado=true;
        }


        // Verificar empate
        else if(Empate(tableroNum)){
            MostrarTablero(tablero);
            cout << "\n¡Empate!\n";
            JuegoTerminado=true;
        }


        else{
            // Cambiar turno usando operador ternario
            jugadorActual = (jugadorActual=='X') ? 'O' : 'X';
        }

    } while(JuegoTerminado==false);

    return 0;
}

