#include <iostream>
#include <fstream>
#include "bst.h"
using namespace std;

int main() {
    node* root = NULL;
    string command;
    int value;

    system("cls"); // Use "cls" instead of "clear" on Windows
    cout << "=== GESTOR DE NUMEROS CON ARBOL BST ===\n";
    cout << "Escriba 'help' para ver los comandos.\n\n";

    while (true) {
        cout << "> ";
        cin >> command;

        if (command == "insert") {
            cin >> value;
            root = insert(root, value);
            cout << "Numero insertado.\n";
        }

        else if (command == "search") {
            cin >> value;
            if (search(root, value) != NULL)
                cout << "El numero SI existe.\n";
            else
                cout << "El numero NO existe.\n";
        }

        else if (command == "delete") {
            cin >> value;
            root = deleteNode(root, value);
            cout << "Numero eliminado.\n";
        }

        else if (command == "inorder") {
            inorder(root);
            cout << endl;
        }

        else if (command == "preorder") {
            preorder(root);
            cout << endl;
        }

        else if (command == "postorder") {
            postorder(root);
            cout << endl;
        }

        else if (command == "height") {
            cout << "Altura: " << height(root) << endl;
        }

        else if (command == "size") {
            cout << "Numero de nodos: " << size(root) << endl;
        }

        else if (command == "export") {
            ofstream file("inorden.txt");
            exportInorder(root, file);
            file.close();
            cout << "Recorrido inorden exportado a inorden.txt\n";
        }

        else if (command == "help") {
            cout << "\nCOMANDOS DISPONIBLES\n";
            cout << "insert [num]\n";
            cout << "search [num]\n";
            cout << "delete [num]\n";
            cout << "inorder\n";
            cout << "preorder\n";
            cout << "postorder\n";
            cout << "height\n";
            cout << "size\n";
            cout << "export\n";
            cout << "exit\n\n";
        }

        else if (command == "exit") {
            break;
        }

        else {
            cout << "Comando invalido.\n";
        }
    }

    return 0;
}
