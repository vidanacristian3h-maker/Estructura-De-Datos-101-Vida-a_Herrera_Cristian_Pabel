#include <iostream>
#include "bst.h"
using namespace std;

// =======================
// CREAR NUEVO NODO
// =======================
node* createNode(int value) {
    node* newNode = new node();
    newNode->data = value;
    newNode->left = NULL;
    newNode->right = NULL;
    return newNode;
}

// =======================
// INSERTAR EN BST
// =======================
node* insert(node* root, int value) {
    if (root == NULL)
        return createNode(value);

    if (value < root->data)
        root->left = insert(root->left, value);
    else if (value > root->data)
        root->right = insert(root->right, value);

    return root;
}

// =======================
// BUSCAR EN BST
// =======================
node* search(node* root, int value) {
    if (root == NULL || root->data == value)
        return root;

    if (value < root->data)
        return search(root->left, value);

    return search(root->right, value);
}

// =======================
// SUCESOR INORDEN
// =======================
node* minValueNode(node* root) {
    node* current = root;
    while (current && current->left != NULL)
        current = current->left;
    return current;
}

// =======================
// ELIMINAR EN BST
// =======================
node* deleteNode(node* root, int value) {
    if (root == NULL)
        return root;

    if (value < root->data)
        root->left = deleteNode(root->left, value);
    else if (value > root->data)
        root->right = deleteNode(root->right, value);
    else {
        // CASO 1: Nodo hoja
        if (root->left == NULL && root->right == NULL) {
            delete root;
            return NULL;
        }
        // CASO 2: Un solo hijo
        else if (root->left == NULL) {
            node* temp = root->right;
            delete root;
            return temp;
        }
        else if (root->right == NULL) {
            node* temp = root->left;
            delete root;
            return temp;
        }
        // CASO 3: Dos hijos
        else {
            node* temp = minValueNode(root->right);
            root->data = temp->data;
            root->right = deleteNode(root->right, temp->data);
        }
    }
    return root;
}

// =======================
// RECORRIDOS
// =======================
void inorder(node* root) {
    if (root != NULL) {
        inorder(root->left);
        cout << root->data << " ";
        inorder(root->right);
    }
}

void preorder(node* root) {
    if (root != NULL) {
        cout << root->data << " ";
        preorder(root->left);
        preorder(root->right);
    }
}

void postorder(node* root) {
    if (root != NULL) {
        postorder(root->left);
        postorder(root->right);
        cout << root->data << " ";
    }
}

// =======================
// ALTURA
// =======================
int height(node* root) {
    if (root == NULL)
        return -1;

    int hi = height(root->left);
    int hd = height(root->right);

    return 1 + (hi > hd ? hi : hd);
}

// =======================
// TAMAÑO
// =======================
int size(node* root) {
    if (root == NULL)
        return 0;
    return 1 + size(root->left) + size(root->right);
}

// =======================
// EXPORTAR INORDEN
// =======================
void exportInorder(node* root, ofstream& file) {
    if (root != NULL) {
        exportInorder(root->left, file);
        file << root->data << " ";
        exportInorder(root->right, file);
    }
}
