#include <iostream>
#include <cmath>
using namespace std;

int fibo(int n, int * fibo_value){
    if(fibo_value[n] != -1){
        return fibo_value[n];
    }
    
    fibo_value[n] = fibo(n - 1, fibo_value) + fibo(n - 2, fibo_value);
    return fibo_value[n];
}

int fibo_with_golden_ratio(int n){
    double phi = (1 + sqrt(5)) / 2.0;

    return round(pow(phi, n) / sqrt(5));
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
    cout << fibo_with_golden_ratio(n) << endl;

    return 0;
}