using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aishishaifa
{
    class Program
    {
       public static void Main()
        {
            Boolean[] array = new Boolean[101];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = true;
            }
             for (int i = 2; i <= 100; i++)
                {
                for (int j = 2 * i; j <= 100; j += i)
                {
                    array[j] = false;
                }
                for (int j = 3* i; j <= 100; j += i)
                {
                    array[j] = false;
                }
                for (int j=5*i; j <= 100; j += i)
                {
                    array[j] = false;
                }
                for (i = 2; i <= 100; i++)
                {
                    if (array[i]==true)
                        Console.WriteLine($"2-100内的素数为{i}");
                }
               
            }
        }
    }
}
