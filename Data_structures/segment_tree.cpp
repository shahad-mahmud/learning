/*
* This code follows the tutorial of Shafaet vai's segment tree blog.
* link of the blog: http://www.shafaetsplanet.com/?p=1557
*/

#include <iostream>
#include <cmath>
using namespace std;

#define mx 10001

int arr[mx];
int tree[mx * 3];

// at first write a function to make the tree form the 
// given array. It will be done in recursive way
void make_tree(int current_node, int begin, int end){
    // 'current_node' is the index of the node we are currently in
    // 'begin' is the start of the range
    // 'end' is the end of the range

    if(begin == end){
        // this is a leaf node
        // sum is the value of the current node as it is the leaf node
        tree[current_node] = arr[begin];
        return;
    }

    // get the left and right child's index
    int left = current_node * 2;
    int right = current_node * 2 + 1;

    // get the mid of the range to divide into sub range
    int mid = (begin + end) / 2;

    // continue to the left and right part of the tree
    make_tree(left, begin, mid);
    make_tree(right, mid + 1, end);

    // get the sum of the left and right sub tree or leaf
    tree[current_node] = tree[left] + tree[right];
}

// function to get the sum of a query
int get_sum(int current_node, int start, int end, int query_start, int query_end){
    // 'current_node' is the index of the node we are currently in
    // 'begin' is the start of the range the 'current_node' is in
    // 'end' is the end of the range the 'current_node' is in
    // 'query_start' is the start of the querying range
    // 'query_end' is the end of the querying range
    
    // at first check if the current segment is relevent or not
    if(query_start > end || query_end < start){
        // Current range does not contain the querying range
        return 0;
    }
    if(start >= query_start && end <= query_end){
        // this is a relevent segment. retrun the sum
        return tree[current_node];
    }

    // some portion of the querying range is in the node range
    // break the range and start query angain
    // get the left and right child's index
    int left = current_node * 2;
    int right = current_node * 2 + 1;

    // get the mid of the range to divide into sub range
    int mid = (start + end) / 2;
    
    // sum of the left part
    int left_sum = get_sum(left, start, mid, query_start, query_end);   
    // sum of the right part
    int right_sum = get_sum(right, mid + 1, end, query_start, query_end);

    return left_sum + right_sum;
}


// function to update a value in the array
void update(int current_node, int start, int end, int query_start, int query_end, int value){
    // 'current_node' is the index of the node we are currently in
    // 'begin' is the start of the range the 'current_node' is in
    // 'end' is the end of the range the 'current_node' is in
    // 'query_start' is the start of the querying range
    // 'query_end' is the end of the querying range
    // 'value' is the value to update

    // at first check if the current segment is relevent or not
    if(query_start > end || query_end < start){
        // Current range does not contain the querying range
        return;
    }
    if(start >= query_start && end <= query_end){
        // this is a relevent segment. update the value
        tree[current_node] = value;
        return;
    }

    // get the left and right child's index
    int left = current_node * 2;
    int right = current_node * 2 + 1;

    // get the mid of the range to divide into sub range
    int mid = (start + end) / 2;

    // update in left subtree
    update(left, start, mid, query_start, query_end, value);
    // update in right ssubtree
    update(right, mid + 1, end, query_start, query_end, value);

    tree[current_node] = tree[left] + tree[right];
}

int main(){
    int n;

    cin >> n;
    for(int i = 1; i <= n; i++){
        scanf("%d", &arr[i]);
    }

    make_tree(1, 1, n);

    cout << get_sum(1, 1, n, 1, n) << endl;
    cout << get_sum(1, 1, n, 1, 3) << endl;

    update(1, 1, n, 2, 2, 10);
    cout << get_sum(1, 1, n, 1, 3) << endl;

    return 0;
}