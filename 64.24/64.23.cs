using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64._23
{
    class Program
    { 
        public static int calc(int[,] a, int x1, int x2, int y1, int y2) //подсчет суммы элементов подматрицы
        {
            if (x1 == 0 && y1 == 0)
                return a[x2, y2];
            else if
                (x1 == 0)
                return a[x2, y2] - a[x2, y1 - 1];
            else if
                (y1 == 0)
                return a[x2, y2] - a[x1 - 1, y2]; 
            else
                return a[x2, y2] - a[x2, y1 - 1] - a[x1 - 1, y2] + a[x1 - 1, y1 - 1];
        }
        
        static void Main(string[] args)
        {
            int i, j, x, y, x1, x2, y1, y2, max, rx1, rx2, ry1, ry2;
            rx1 = 0;
            rx2 = 0;
            ry1 = 0;
            ry2 = 0;
            max = -9999999;
            Random rand = new Random();
            int N = Convert.ToInt32(Console.ReadLine()); //размер матрицы 
            int[,] arr = new int[N, N];
            int[,] sum = new int[N, N];
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                {
                    arr[i, j] = rand.Next(-1, 2);
                    for (x = 0; x <= i; x++) //заполняем массив sum как сумму с (0,0) до ()
                        for (y = 0; y <= j; y++)
                            sum[i, j] += arr[x, y];
                    Console.Write(arr[i, j] + "\t");
                    if (j == N - 1)
                        Console.WriteLine();
                }
            Console.WriteLine();
            for (x1 = 0; x1 < N; x1++)
                for (x2 = x1; x2 < N; x2++)
                    for(y1 = 0; y1 < N; y1++)
                        for(y2 = y1; y2 < N; y2++)
                        {
                            if (calc(sum, x1, x2, y1, y2) >= max)//пробегаем по матрице всеми подматрицвми
                            {
                                max = calc(sum, x1, x2, y1, y2);
                                rx1 = x1;
                                rx2 = x2;
                                ry1 = y1;
                                ry2 = y2;
                            }
                        }
            for(i = rx1; i <= rx2; i++) //печатаем получившуюся матрицу
                for (j = ry1; j <= ry2; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                    if (j == ry2)
                        Console.WriteLine();
                }
            Console.ReadLine();
        }
    }
}
