using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            int i;
            Console.WriteLine("请输入数组元素的个数:");
            i = int.Parse(Console.ReadLine());
            Console.WriteLine("接下来请输入{i}个数：");
            array = new int[i];
            for (int k = 0; k < i; k++)
                array[i] = int.Parse(Console.ReadLine());
            max(array);
            min(array);
            sumandaverage(array);

        }

        public static void max(int[] a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (max < a[i])
                    max = a[i];
                Console.WriteLine($"最大值为{max}");
            }
        }
        public static void min(int[] a)
        {
            int min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (min > a[i])
                    min = a[i];
                Console.WriteLine($"最小值为{min}");
            }
        }
        public static void sumandaverage(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
                Console.WriteLine($"和为{sum}");
            }
            double average = 0;
            for (int i = 0; i < a.Length; i++)
            {
                average = (double)(sum / a.Length);
                Console.WriteLine($"平均数为{average}");
            }

        }
    }
}
