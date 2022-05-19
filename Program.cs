using static System.Console;
using System.Collections.Generic;

    class Matrix {
        int size;
        int[,] a;
        
        public Matrix(int n) {
            size = n;
            a = new int[n, n];
        }
        
        public void read() {
            for (int i = 0 ; i < size ; ++i) {
                string[] words = ReadLine().Trim().Split(null);
                if (words.Length != size) {
                    WriteLine("bad input");
                    return;
                }
                for (int j = 0 ; j < size ; ++j)
                    a[i, j] = int.Parse(words[j]);
            }
        }

        public static Matrix operator + (Matrix x, Matrix y){
            Matrix result = new Matrix(x.size);
            for(int i = 0; i < x.size; ++i)
                for(int j = 0; j < x.size; ++j)
                    result.a[i,j] = x.a[i,j] + y.a[i,j];

            return result;
        }

        public static Matrix operator - (Matrix x, Matrix y){
            Matrix result = new Matrix(x.size);
            for(int i = 0; i < x.size; ++i)
                for(int j = 0; j < x.size; ++j)
                    result.a[i,j] = x.a[i,j] - y.a[i,j];

            return result;
        }

        public static Matrix operator * (Matrix x, Matrix y){
            Matrix result = new Matrix(x.size);
            for(int i = 0; i < x.size; ++i)
                for(int j = 0; j < x.size; ++j){
                    result.a[i,j] = 0;
                    for(int k = 0; k < x.size; ++k)
                        result.a[i,j] += x.a[i,k] * y.a[k,j];
                }
                
            return result;
        }

        public void print() {
            for(int i = 0; i < size; ++i){
                for(int j = 0; j < size; ++j)
                    Write($"{a[i,j]} ");
                WriteLine();
            }
        }
}



    class Program{
        static void Main(string[] args){
            string [] line = ReadLine().Split(null);
            
            int n = int.Parse(line[0]);
            int numberOfMatrices = int.Parse(line[1]);

            Matrix [] matrices = new Matrix [numberOfMatrices];

            for(int i = 0; i < numberOfMatrices; ++i){
                matrices[i] = new Matrix(n);
                matrices[i].read();
                ReadLine();
            }

            string [] postfix = ReadLine().Split(null);
            Stack<Matrix> eval = new Stack<Matrix>();

            for(int i = 0; i < postfix.Length; ++i){

                if ("+-*".Contains(postfix[i])){

                    Matrix temp1;
                    Matrix temp2;

                    switch(postfix[i]){
                        case "+":
                            temp1 = eval.Pop();
                            temp2 = eval.Pop();
                            eval.Push(temp1 + temp2);
                            break;

                        case "-":
                            temp2 = eval.Pop();
                            temp1 = eval.Pop();
                            eval.Push(temp1 - temp2);
                            break;

                        case "*":
                            temp2 = eval.Pop();
                            temp1 = eval.Pop();
                            eval.Push(temp1 * temp2);
                            break;
                    }
                }
                else
                    eval.Push(matrices[int.Parse(postfix[i]) - 1]);
            }

            eval.Pop().print();

        }
    }
