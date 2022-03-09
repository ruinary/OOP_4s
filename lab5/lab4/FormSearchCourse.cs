using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class FormSearchCourse : Form
    {
        public FormSearchCourse()
        {
            InitializeComponent();
            textBox1.Tag = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Results.result.Clear();
            if ((bool)textBox1.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (x.Course == textBox1.Text)
                    {
                        Results.result.Add(x);
                    }
                }
            }
            Results formRes = new Results();
            formRes.Show();
        }
        private void EnableButton()
        {
            button4.Enabled = (bool)textBox1.Tag;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"[1-4]$"))
            {
                textBox1.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                textBox1.Tag = false;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.Tag = true;
            }
            EnableButton();
        }
    }
}
