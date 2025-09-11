using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFB_Demo1
{
    public partial class Form3 : Form
    {
        int num1, num2, result;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            num1 = int.Parse(textBox1.Text);
            num2 = int.Parse(textBox2.Text);

            result = num1 - num2;

            label3.Text = result.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            num1 = int.Parse(textBox1.Text);
            num2 = int.Parse(textBox2.Text);

            result = num1 + num2;

            label3.Text = result.ToString();
        }
    }
}
