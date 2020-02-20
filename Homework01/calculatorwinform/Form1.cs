using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorwinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//+

            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            float flNum1 = Convert.ToSingle(strNum1);
            float flNum2 = Convert.ToSingle(strNum2);
            float result = flNum1 + flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//减
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            float flNum1 = Convert.ToSingle(strNum1);
            float flNum2 = Convert.ToSingle(strNum2);
            float result = flNum1 - flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {//乘法
            string strNum1 = textBox1.Text;
            if (string.IsNullOrEmpty(strNum1))
            {
                strNum1 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            string strNum2 = textBox2.Text;
            if (string.IsNullOrEmpty(strNum2))
            {
                strNum2 = "0";
                MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            float flNum1 = Convert.ToSingle(strNum1);
            float flNum2 = Convert.ToSingle(strNum2);
            float result = flNum1 * flNum2;
            textBox3.Text = Convert.ToString(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {//除法
                string strNum1 = textBox1.Text;
                if (string.IsNullOrEmpty(strNum1))
                {
                    strNum1 = "0";
                    MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                string strNum2 = textBox2.Text;
                if (string.IsNullOrEmpty(strNum2))
                {
                    strNum2 = "0";
                    MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                if (int.Parse(strNum2) == 0)
                {
                    MessageBox.Show("请检查并重新输入正确的值！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                float flNum1 = Convert.ToSingle(strNum1);
                float flNum2 = Convert.ToSingle(strNum2);
                float result = flNum1 / flNum2;
                textBox3.Text = Convert.ToString(result);
            }

        }
    }
}
