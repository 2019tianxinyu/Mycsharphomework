using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        public int th1;//右分支角度
        public int th2;//左分支角度
        public double per1;//分支长度比1
        public double per2;//分支长度比2
        public double leng
        {
            get { return Double.Parse(textBox2.Text); }
            set { }
           
        }
         //主干高度
        public int n;//迭代次数
        public Pen DrawPen;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            th1 = 70;
            th2 = 60;
            per1 = 0.6;
            per2 = 0.7;
            leng = 50;
            n = 20;


            DrawPen = Pens.Red;
            Pen[] pens = { Pens.Blue, Pens.Yellow, Pens.Red,Pens.Pink,Pens.Green,Pens.Orange,Pens.Black,Pens.Purple};

        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.panel1.CreateGraphics();
            }
            graphics.Clear(panel1.BackColor);
            drawCayLeyTree(this.n, panel1.Width / 2, panel1.Height - 20, this.leng, -Math.PI/2);


        }



        void drawCayLeyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double th1 = Double.Parse(textBox3.Text);
            double th2 = Double.Parse(textBox4.Text);
            double per1 = Double.Parse(textBox5.Text) / 100;
            double per2 = Double.Parse(textBox6.Text) / 100;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            graphics.DrawLine(DrawPen, (int)x0,(int) y0,(int) x1,(int) y1);
            

            drawCayLeyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayLeyTree(n - 1, x1, y1, per2 * leng, th - th2);


           
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
    }

 

