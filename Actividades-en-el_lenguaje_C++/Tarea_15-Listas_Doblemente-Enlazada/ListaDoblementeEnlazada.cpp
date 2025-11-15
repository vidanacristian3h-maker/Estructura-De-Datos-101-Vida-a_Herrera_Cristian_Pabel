#include <iostream>
#include <string>    
#include <stdexcept> 

using namespace std;

struct Node {
    int data;
    Node* next;
    Node* prev;

    Node(int d) {
        data = d;
        next = nullptr;
        prev = nullptr;
    }
};

// efinición de la Lista 
class DoublyLinkedList {
private:
    Node* head;
    Node* tail;

public:
    DoublyLinkedList() {
        head = nullptr;
        tail = nullptr;
    }

    ~DoublyLinkedList() {
        Node* current = head;
        while (current != nullptr) {
            Node* next = current->next;
            delete current;
            current = next;
        }
    }

    void append(int data) {
        Node* newNode = new Node(data);
        if (head == nullptr) {
            head = newNode;
            tail = newNode;
        } else {
            tail->next = newNode;
            newNode->prev = tail;
            tail = newNode;
        }
    }

    void printForward() {
        Node* current = head;
        cout << "\n--- Tu Lista (Adelante) ---\n";
        cout << "HEAD <-> ";
        while (current != nullptr) {
            cout << current->data << " <-> ";
            current = current->next;
        }
        cout << "NULL\n";
    }

    void printBackward() {
        Node* current = tail;
        cout << "\n--- Tu Lista (Atras) ---\n";
        cout << "NULL <-> ";
        while (current != nullptr) {
            cout << current->data << " <-> ";
            current = current->prev;
        }
        cout << "HEAD\n";
    }
    
};

int main() {
    DoublyLinkedList miLista;
    string input; //para guardar

    cout << "--- Creador de Listas Dobles en C++ ---\n";

    while (true) {
        cout << "Escribe un numero para agregar (o 'salir'): ";
        cin >> input; // Lee la entrada del usuario

        if (input == "salir") {
            break; 
        }

        try {
            // 'stoi' significa "string to integer" (convertir texto a número)
            int data = stoi(input);
            
            // Si funciona, lo agregamos
            miLista.append(data);
            
            // estado actual de la lista
            miLista.printForward();
            
        } catch (const invalid_argument& e) {
            // Esto se ejecuta si 'stoi' falla (ej. "hola")
            cout << "Error: '" << input << "' no es un numero valido. Intenta de nuevo.\n";
        }
    }

    cout << "\n--- Lista Final Completa ---";
    miLista.printForward();
    miLista.printBackward();
    cout << "\n¡Adiós!\n";

    return 0;
}