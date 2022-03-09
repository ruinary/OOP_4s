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
    public partial class FormSearchSpec : Form
    {
        public FormSearchSpec()
        {
            InitializeComponent();
            textBox1.Tag = false;
            textBox2.Tag = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Results.result.Clear();
            if ((bool)textBox1.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (x.Profession == textBox1.Text)
                    {
                        Results.result.Add(x);
                    }
                }
            }
            else if ((bool)textBox2.Tag == true)
            {

                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (Regex.IsMatch(x.Profession, "^" + textBox2.Text))
                    {
                        Results.result.Add(x);
                    }
                }
            }
            Results formRes = new Results();
            formRes.Show();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"([А-Я]*[а-я]*)*$"))
            {
                textBox1.Tag = false;
                textBox1.BackColor = ColorTranslator.FromHtml("#ff8d8d");
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.Tag = true;
            }
            EnableButton();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox2.Text, @"[А-Я]$"))
            {
                textBox2.Tag = false;
                textBox2.BackColor = ColorTranslator.FromHtml("#ff8d8d");
            }
            else
            {
                textBox2.BackColor = Color.White;
                textBox2.Tag = true;
            }
            EnableButton();
        }
        private void EnableButton()
        {
            button4.Enabled = (bool)textBox1.Tag || (bool)textBox2.Tag;
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && ((textBox2.Text == "")))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
            }
            if ((textBox1.Text == "") && ((textBox2.Text != "")))
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
            }
            if ((textBox1.Text == "") && ((textBox2.Text == "")))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }
    }
}
