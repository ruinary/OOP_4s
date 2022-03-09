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
    public partial class FormSearchFIO : Form
    {
        public FormSearchFIO()
        {
            InitializeComponent();
            textBox1.Tag = false;
            textBox2.Tag = false;
            textBox3.Tag = false;
        }

        private void EnableButton()
        {
            if ((bool)textBox1.Tag || (bool)textBox2.Tag || (bool)textBox3.Tag)
            {
                button4.Enabled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && ((textBox2.Text == "") && (textBox3.Text == "")))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            if ((textBox1.Text == "") && ((textBox2.Text != "") && (textBox3.Text == "")))
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
            }
            if ((textBox1.Text == "") && ((textBox2.Text == "") && (textBox3.Text != "")))
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = true;
            }
            if ((textBox1.Text == "") && ((textBox2.Text == "") && (textBox3.Text == "")))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$"))
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

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox2.Text, @"[А-Я]$"))
            {
                textBox2.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                textBox2.Tag = false;
            }
            else
            {
                textBox2.BackColor = Color.White;
                textBox2.Tag = true;
            }
            EnableButton();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox3.Text, @"[А-Я][а-я]+$"))
            {
                textBox3.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                textBox3.Tag = false;
            }
            else
            {
                textBox3.BackColor = Color.White;
                textBox3.Tag = true;
            }
            EnableButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Results.result.Clear();
            if ((bool)textBox1.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (x.FullName == textBox1.Text)
                    {
                        Results.result.Add(x);
                    }
                }
            }
            else if ((bool)textBox3.Tag == true)
            {
                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (Regex.IsMatch(x.FullName, textBox3.Text))
                    {
                        Results.result.Add(x);
                    }
                }
            }
            else if ((bool)textBox2.Tag == true)
            {

                foreach (Student x in Form1.studentListControl.studentList)
                {
                    if (Regex.IsMatch(x.FullName, "^" + textBox2.Text))
                    {
                        Results.result.Add(x);
                    }
                }
            }
            Results formRes = new Results();
            formRes.Show();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
