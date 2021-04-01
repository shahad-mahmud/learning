#include <iostream>
#include <cmath>
#include <algorithm>
using namespace std;

#define sci(x) scanf("%d", &x)
#define print(x) printf("%d ", x)

struct Node{
    int data;
    Node *nextNode;
};

Node* addToList(Node *root, int data){
    if(root == NULL){
        Node *newNode = new Node;
        newNode->data = data;
        newNode->nextNode = NULL;
        return newNode;
    }

    root->nextNode = addToList(root->nextNode, data);
    return root;
}

void printList(Node *head){
    if(head == NULL){
        return;
    }
    print(head->data);
    printList(head->nextNode);
}

int main(){
    Node *headPtr = NULL;

    headPtr = addToList(headPtr, 2);
    headPtr = addToList(headPtr, 3);
    headPtr = addToList(headPtr, 4);
    headPtr = addToList(headPtr, 5);

    printList(headPtr);

    return 0;
}