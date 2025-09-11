using MarkStudentEntryApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkStudentEntryApp
{
    public partial class Form1 : Form
    {
        public List<Student> studentList = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudentId = int.Parse(textBox1.Text);
            student.StudentName = textBox2.Text;
            student.Scores = int.Parse(textBox3.Text);

            if (student != null)
            {
                studentList.Add(student);
                MessageBox.Show("Record Added!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

            }
            else
            {
                MessageBox.Show("Please Enter the Valid Input!!");
            }

            foreach (var item in studentList)
            {
                Console.WriteLine(item.StudentName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(studentList);
            form2.Show();
        }
    }
}
