#include <iostream>
using namespace std;

int fibo(int n, int * fibo_value){
    if(fibo_value[n] != -1){
        return fibo_value[n];
    }
    
    fibo_value[n] = fibo(n - 1, fibo_value) + fibo(n - 2, fibo_value);
    return fibo_value[n];
}

int main(){
    int n = 9;
    int fibo_value[n + 2];

    for(int i = 0; i < n + 2; i++){
        fibo_value[i] = -1;
    }

    fibo_value[0] = 0;
    fibo_value[1] = 1;

    cout << fibo(n, fibo_value) << endl;

    return 0;
}