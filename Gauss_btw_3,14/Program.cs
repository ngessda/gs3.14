﻿using System;
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
                {3,2,-5,-1},
                {2,-1,3,13},
                {1,2,-1,9},
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
                double maxValue = arr[i, i % m];
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(arr[j, i % m]) > Math.Abs(maxValue))
                    {
                        maxValue = arr[j, i];
                        for (int k = 0; k < m; k++)
                        {
                            double t = arr[i, k];
                            arr[i, k] = arr[j, k];
                            arr[j, k] = t;
                        }
                    }
                }
                if (Math.Abs(maxValue) > eps)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        double koef = arr[j, i] / maxValue;
                        for (int k = 0; k < m; k++)
                        {
                            arr[j, k] -= arr[i, k] * koef;
                            if (Math.Abs(arr[j, k]) < eps)
                            {
                                arr[j, k] = 0;
                            }
                        }
                    }
                }
            }
            //for (int i = 0; i < n; i++)
            //{
            //    if (Math.Abs(arr[i, i]) != 1)
            //    {
            //        bool counter = false;
            //        for (int j = i + 1; j < n; j++)
            //        {
            //            if (Math.Abs(arr[j, i]) == 1)
            //            {
            //                counter = true;
            //                for (int k = 0; k < m; k++)
            //                {
            //                    var t = arr[i, k];
            //                    arr[i, k] = arr[j, k];
            //                    arr[j, k] = t;
            //                }
            //            }
            //        }
            //        if (!counter)
            //        {
            //            for (int j = i + 1; j < n; j++)
            //            {
            //                if (arr[j, i] != 0 && Math.Abs(arr[j, i] % arr[i, i]) == 1)
            //                {
            //                    for (int k = 0; k < m; k++)
            //                    {
            //                        if (arr[j, i] > 0)
            //                        {
            //                            arr[i, k] -= arr[j, k];
            //                        }
            //                        else
            //                        {
            //                            arr[i, k] += arr[j, k];
            //                        }
            //                    }
            //                    break;
            //                }
            //                else
            //                {
            //                    var val = arr[i, i];
            //                    for (int k = i; k < m; k++)
            //                    {
            //                        arr[i, k] /= val;
            //                    }
            //                }
            //            }
            //        }

            //    }
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        var x = arr[j, i] / arr[i, i];
            //        for (int k = 0; k < m; k++)
            //        {
            //            arr[j, k] -= arr[i, k] * x;
            //            if (Math.Abs(arr[j, k]) < eps)
            //            {
            //                arr[j, k] = 0;
            //            }
            //        }
            //    }
            //    if (i == n - 1)
            //    {
            //        double v = arr[i, i];
            //        for (int j = i; j < m; j++)
            //        {
            //            arr[i, j] /= v;
            //        }
            //    }
            //    if (arr[i, i] < 0)
            //    {
            //        for (int j = i; j < m; j++)
            //        {
            //            arr[i, j] *= -1;
            //        }
            //    }
            //    Print(arr);
            //}
        }
        public static bool Check(double[,] arr)
        {
            const double eps = 0.00001;
            bool result = true;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);
            int c;
            for(int i = 0; i < n; i++)
            {
                c = 0;
                for(int j = 0; j < m; j++)
                {
                    if (double.IsNaN(Math.Abs(arr[i, j])) || Math.Abs(arr[i,j]) < eps)
                    {
                        c++;
                    }
                }
                if(c == m - 1)
                {
                    Console.WriteLine("Система несовместима...");
                    result = false;
                    break;
                }
                else if(c == m)
                {
                    Console.WriteLine("Система имеет бесконечное множество решений...");
                    result = false;
                    break;
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
            if (Check(arr))
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
                    res[i, 0] /= arr[i, i];
                }
                Print(res);
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
