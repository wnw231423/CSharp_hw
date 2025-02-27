using System;
using System.Data;

namespace Assignment2
{
    public class Program
    {
        static void Main(string[] args) 
        {
            
        }

        /* Given an integer n, return a set of it's prime factors. */
        public static SortedSet<int> GetPrimeFactor(int n) 
        {
            int factor = 2;
            SortedSet<int> res = new SortedSet<int>();
            while (factor <= n) 
            {
                int divided = n / factor;
                int mod = n % factor;
                if (mod == 0)
                {
                    res.Add(factor);
                    n = divided;
                }
                else {
                    factor += 1;
                }
            }
            return res;
        }

        /* Given a int[] lst, return a int[4] which inlcudes max, min
         * average and sum of lst. */
        public static int[] ArrayInfo(int[] lst)
        {
            if (lst.Length == 0)
            {
                throw new ArgumentException("no infomation for empty array");
            }

            int[] res = new int[4];
            res[0] = lst.Max();
            res[1] = lst.Min();
            res[3] = lst.Sum();
            res[2] = res[3] / lst.Length;
            return res;
        }

        /* return a set of prime <= n, using the sieve of Eratosthenes */
        public static SortedSet<int> Eratosthenes(int n) 
        {
            SortedSet<int> res = new SortedSet<int>();
            bool[] is_prime = new bool[n];
            for (int i = 1; i < n; i++) 
            {
                is_prime[i] = true;
            }

            for (int i = 2; i <= n; i++) 
            {
                if (is_prime[i - 1]) 
                {
                    res.Add(i);
                    for (int j = 2 * i; j <= n; j += i) 
                    {
                        is_prime[j - 1] = false;
                    }
                }
            }

            return res;
        }

        public static bool IsToeplitzMatrix(int[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                    { 
                        return false;
                    }
                }
            }
            return true;
        }
    }
}