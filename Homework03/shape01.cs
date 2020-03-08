using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shape01
{
    public abstract class shape01
    {
        public abstract double area();//计算面积的抽象方法
    }

    interface Reasonable
    {
        bool Reasonable();
    }
    class rectangle : shape01,Reasonable//长方形类
    {
       
        public double length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }

        }
        public double width
        {
            get
            {
                return width;
            }
             set
            {
                length = value;
            }

        }
        public rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }


        public override double area()
        {
            return length * width;
        }
        public bool  Reasonable(double length,double width)
        {
            if (length > 0 && width > 0 && length > width)
     
                return true;
         
            else
                return false;


         }
        
     
    }    
    class square : shape01,Reasonable//正方形类
    {
        private double sidelength;
        public double sidelength
        {
            get;
            set;
        }
        public square(double sidelength)
        {
            this.sidelength = sidelength;
        }
        public override double area()
        {
            return sidelength * sidelength;
        }
        public bool Reasonable(double sidelength)
        {
            if (sidelength > 0)
                return true;
  
            else
                return false;
 
        }
  
    }

    class triangle : shape01,Reasonable//三角形类
    {
        private double length1;
        private double length2;
        private double length3;
        public double length1
        {
            get;
            set;
        }
        public double length2
        {
            get;
            set;
        }
        public double length3
        {
            get;
            set;
        }
        public triangle(double length1,double length2,double length3)
        {
            this.length1 = length1;
            this.length2 = length2;
            this.length3 = length3;

        }
        public override double area()
        {
            double sum = (length1 + length2 + length3) / 2;//海伦公式
            return Math.Sqrt(sum*(sum-length1)*(sum-length2)*(sum-length3));
        }
        public bool Reasonable(double length1,double length2,double length3)
        {
            bool a = length1 > 0 && length2 > 0 && length3 > 0 && (length1 + length2 > length3) && (length2 + length3 > length1) && (length1 + length3 > length2);
            if (a == true)
            {
                return true;
                if(length1 == length2 && length2 == length3)
                {
                    Console.WriteLine("是等边三角形");
                }
                else if (length1 == length2 || length2 == length3 || length3 == length1)
                    Console.WriteLine("是等腰三角形");
            }
            else
                return false;

        }

    }

    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
