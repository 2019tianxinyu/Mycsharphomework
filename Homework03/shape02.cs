using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape02
{
    public interface Shape02
    {
        string creat();
    }
    public class ShapeCreat : Shape02
    {
        public double getrandomshape()
        {
            string[] randomshape = new string[10];
            for (int i = 0; i < num; i++)
            {
                Random random = new Random();
                int j = random.Next(0, 3);//产生位于0~3间的整数
                randomshape[i] = creat(j);
            }
        }
        public double creat(int j)
        {
            switch (j)
            {
                case 0:
                    rectangle rt = new rectangle(height, width);
                    return rt.Area();
                    break;
                case 1:
                    square s = new square(width);
                    return s.Area();
                    break;
                case 2:
                    triangle tr = new triangle(l1, l2, l3);
                    return tr.Area();
                    break;
                default:
                    return null;
                    break;

            }
        }

        abstract class shape
        {
            public abstract double Area();//面积
            public abstract string Initialization();
        }
        class rectangle : shape
        {
            double width;
            double height;
            public override string Initialization()
            {
                return new Random(Guid.NewGuid().GetHashCode()).Next(width, height);

            }
            public override double Area(double w, double h)
            {
                Random random = new Random();
                double w = random.Next(0, 100);
                double h = random.Next(0, 100);
                this.width = w;
                this.height = h;
                return width * height;
            }

        }
        class square : shape
        {
            double width;
            public override double Area(double w)
            {
                Random random = new Random();
                double w = random.Next(0, 100);
                this.width = w;
                return width * width;
            }
            public override string Initialization()
            {
                return new Random(Guid.NewGuid().GetHashCode()).Next(width);

            }

        }
        class triangle : shape
        {
            double l1;
            double l2;
            double l3;
            public override double Area(double a, double b, double c)
            {
                Random random = new Random();
                double a = random.Next(0, 100);
                double b = random.Next(0, 100);
                double c = random.Next(0, 100);
                this.l1 = a;
                this.l2 = b;
                this.l3 = c;
                double p = (l1 + l2 + l3) / 2;
                return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
            }
            public override string Initialization()
            {
                return new Random(Guid.NewGuid().GetHashCode()).Next(l1, l2, l3);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += randomshape[i].Area();
                }
            }
        }
    }
}

