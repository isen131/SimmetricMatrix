using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimmetricMatrix
{
    class Program
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}  ", array[i]);
            }
            Console.WriteLine();
        }

        public static int[,] CreateSimmetricMatrix(int n)
        {
            Random rnd = new Random();
            int tmp = 0;
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    tmp = rnd.Next(0, 11);
                    matrix[i, j] = tmp;
                    matrix[j, i] = tmp;
                }
            }
            return matrix;
        }

        public static int[] Compress(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int count = 0;
            int[] result = new int[(n * n - n) / 2 + n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[count] = matrix[i, j];
                    count++;
                }
            }
            return result;
        }

        public static int[,] Decompress(int[] array)
        {
            int count = array.Length;
            int tmp = 1;
            while(count > tmp)
            {
                count -= tmp;
                tmp++;
            }
            int[,] matrix = new int[count, count];
            tmp = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = array[tmp];
                    matrix[j, i] = array[tmp];
                    tmp++;
                }
            }
            return matrix;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер матрицы");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = CreateSimmetricMatrix(n);
            Console.WriteLine("Исходная симметричная матрица:");
            PrintMatrix(matrix);
            int[] compressedMatrix = Compress(matrix);
            Console.WriteLine("Массив из матрицы:");
            PrintArray(compressedMatrix);
            Console.WriteLine();
            int[,] newMatrix = Decompress(compressedMatrix);
            Console.WriteLine("Матрица из массива:");
            PrintMatrix(newMatrix);
            Console.ReadKey();
        }
    }
}
