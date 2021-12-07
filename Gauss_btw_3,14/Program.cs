using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_btw_3_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] arr = new double[,]
            {
                {2,3,-1,1,1 },
                {8,12,-9,8,3 },
                {4,6,3,-2,3 },
                {2,3,9,-7,3 }
            };
            Gauss(arr);
            GaussRes(arr);
            Console.ReadKey();
        }
        public static void Gauss(double[,] arr)
        {
            const double eps = 0.00001;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(arr[i, i]) != 1)
                {
                    bool counter = false;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (Math.Abs(arr[j, i]) == 1)
                        {
                            counter = true;
                            for (int k = 0; k < m; k++)
                            {
                                var t = arr[i, k];
                                arr[i, k] = arr[j, k];
                                arr[j, k] = t;
                            }
                        }
                    }
                    if (!counter)
                    {
                        for (int j = i + 1; j < n; j++)
                        {
                            if (arr[j, i] != 0 && Math.Abs(arr[j, i] % arr[i, i]) == 1)
                            {
                                for (int k = 0; k < m; k++)
                                {
                                    if (arr[j, i] > 0)
                                    {
                                        arr[i, k] -= arr[j, k];
                                    }
                                    else
                                    {
                                        arr[i, k] += arr[j, k];
                                    }
                                }
                                break;
                            }
                            else
                            {
                                var val = arr[i, i];
                                for (int k = i; k < m; k++)
                                {
                                    arr[i, k] /= val;
                                }
                            }
                        }
                    }

                }
                for (int j = i + 1; j < n; j++)
                {
                    var x = arr[j, i] / arr[i, i];
                    for (int k = 0; k < m; k++)
                    {
                        arr[j, k] -= arr[i, k] * x;
                        if (Math.Abs(arr[j, k]) < eps)
                        {
                            arr[j, k] = 0;
                        }
                    }
                }
                if (i == n - 1)
                {
                    double v = arr[i, i];
                    for (int j = i; j < m; j++)
                    {
                        arr[i, j] /= v;
                    }
                }
                if (arr[i, i] < 0)
                {
                    for (int j = i; j < m; j++)
                    {
                        arr[i, j] *= -1;
                    }
                }
            }
        }

        public static bool CheckForInfinity(double[,] arr)
        {
            const double eps = 0.00001;
            bool result = true;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (Math.Abs(arr[i, j]) < eps)
                    {
                        c++;
                    }
                }
                if (c >= m - 1 && (arr[i,i] == 0 || double.IsNaN(arr[i,i])))
                {
                    result = false;
                }
            }
            return result;
        }
        public static bool CheckForIncompatibility(double[,] arr)
        {
            const double eps = 0.00001;
            bool result = true;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int c = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m - 1; j++)
                {
                    if (double.IsNaN(Math.Abs(arr[i, j])))
                    {
                        c++;
                    }
                }
                if(c >= m - 1)
                {
                    result = false;
                }
            }
            return result;
        }
        public static void GaussRes(double[,] arr)
        {
            int k;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            double[,] res = new double[n, 1];
            if (CheckForIncompatibility(arr))
            {
                if (CheckForInfinity(arr))
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        k = 1;
                        res[i, 0] = arr[i, m - 1];
                        for (int j = i + 1; j < m - 1; j++)
                        {
                            res[i, 0] -= arr[i, j] * res[i + k, 0];
                            k++;
                        }
                    }
                    Print(res);
                }
                else
                {
                    Console.WriteLine("Система имеет бесконечное множество решений");
                }
            }
            else
            {
                Console.WriteLine("Система не совместима");
            }
        }
        public static void Print(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++) 
                {
                    var value = Math.Round(matrix[i,j], 2);
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
