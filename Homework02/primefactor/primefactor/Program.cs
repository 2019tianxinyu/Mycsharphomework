using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primefactor
{
    class Program
    {
         static bool IsPrimeNumber(int m)
        {
            int i;
            for(i=2;i<m+1;i++)
            {
                if (m % i == 0)
                    break;
            }
            if (i == m)
                return true;
            else
                return false;
        }
        
        public static void PrimeFactor(int k)
        {
            int i = 0;
            Console.Write($"{k}的素数因子有：");
            if (!IsPrimeNumber(k))
            {
                for (i = 2; i < k; i++)
                    if (k % i == 0 && IsPrimeNumber(i) == true)
                    {
                        k /= i;
                        Console.Write($"{i} ");
                      
                    }
            }
            else
                Console.Write($"{k}");
           
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个大于一的自然数:");
            int n = int.Parse(Console.ReadLine());
            while (n <= 1)
            {
                Console.WriteLine("请重新输入：");
                n = int.Parse(Console.ReadLine());
            }
            PrimeFactor(n);
        }

    }
}
