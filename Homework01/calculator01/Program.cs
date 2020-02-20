using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator01
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("请输入一个整数：");
            string num1 = Console.ReadLine();
            int number1 = CheckNum(num1);
            Console.WriteLine("请输入第二个整数：");
            string num2 = Console.ReadLine();
            int number2 = CheckNum(num2);
            //选择运算符
            Console.WriteLine("请选择运算符：1.+  2.-  3.x  4.÷ ");
            string fun = Console.ReadLine();
            GetResualt(fun, number1, number2);
            Console.ReadLine();
        }

//错误处理，检测是否是整数，不是的话打印提示
        static int CheckNum(string num)
        {
            try
            {
                int i = int.Parse(num);
                return i;
            }
            catch (Exception e)
            {
                Console.WriteLine("输入有误，请重新输入：");
                string str = Console.ReadLine();
                //递归算法
                return CheckNum(str);
            }
        }
        //进行运算
        static void GetResualt(string fun, int num1, int num2)
        {
            int res = 0;
            string yun = "";
            switch (fun)
            {
                case "1":
                    res = num1 + num2;
                    yun = "+";
                    break;
                case "2":
                    res = num1 - num2;
                    yun = "-";
                    break;
                case "3":
                    res = num1 * num2;
                    yun = "x";
                    break;
                case "4":
                    res = num1 / num2;
                    yun = "÷";
                    break;
                default:
                    Console.WriteLine("请重新选择运算符：");
                    string str = Console.ReadLine();
                    GetResualt(str, num1, num2);
                    return;
            }
            Console.WriteLine("{0}{1}{2}={3}", num1, yun, num2, res);
        }
    }
}
