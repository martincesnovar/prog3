<Query Kind="Program" />

void Main()
{
	int[,] A = new int[3,3]{{1,0,0},{1,1,0},{0,0,1}};
	int[,] B = new int[3,4]{{0,0,0,0},{0,0,0,0},{0,0,0,1}};
	int[,] C = Multiply(A,B);
	Console.Write(A);
	Console.Write(B);
	Console.Write(C);
}

 int[,] Multiply(int[,] A, int[,] B)
        {

            int[,] res = new int[A.GetLength(0),B.GetLength(1)];
            bool[] rowA = new bool[A.GetLength(0)];
            bool[] colB = new bool[B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    if (A[i,j] != 0)
                    {
                        rowA[i] = true;
                        break;
                    }
            }
            for (int j = 0; j < B.GetLength(1); j++)
            {
                for (int i = 0; i < B.GetLength(0); i++)
                    if (B[i,j] != 0)
                    {
                        colB[j] = true;
                        break;
                    }
            }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int k = 0; k < B.GetLength(1); k++)
                {
                    if (!rowA[i] || !colB[k])
                    {
                        res[i,k] = 0;
                        continue;
                    }

                    int sum = 0;
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        sum += A[i,j] * B[j,k];
                    }
                    res[i,k] = sum;
                }
            }
            return res;
        }