#ifndef BST_H
#define BST_H

#include <fstream>
using namespace std;

// ===== ESTRUCTURA DEL NODO =====
struct node {
    int data;
    node* left;
    node* right;
};

// ===== PROTOTIPOS DE FUNCIONES =====
node* createNode(int value);
node* insert(node* root, int value);
node* search(node* root, int value);
node* deleteNode(node* root, int value);
node* minValueNode(node* root);

void inorder(node* root);
void preorder(node* root);
void postorder(node* root);

int height(node* root);
int size(node* root);

void exportInorder(node* root, ofstream& file);

#endif
