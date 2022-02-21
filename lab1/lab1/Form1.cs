using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab1
{
    public partial class Calculator : Form
    {
        string path = @"D:\study\2 курс\OОП\lab1\file.txt";
        double val = 0;
        string op = "";
        bool op_pressed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((resultBar.Text == "0") || (op_pressed)) { resultBar.Clear(); }
            op_pressed = false;
            Button b = (Button)sender;
            resultBar.Text = resultBar.Text + b.Text;
        }
        private void buttonDelOne_Click(object sender, EventArgs e)
        {
            if(resultBar.Text.Length>0)
            resultBar.Text = resultBar.Text.Remove(resultBar.Text.Length -1) ;
        }

        private void buttonDelAll_Click(object sender, EventArgs e)
        {
            resultBar.Text = "0";
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            op = b.Text;
            val = Double.Parse(resultBar.Text);
            op_pressed = true;
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case "+": resultBar.Text = (val + Double.Parse(resultBar.Text)).ToString();
                    break;
                case "-":
                    resultBar.Text = (val - Double.Parse(resultBar.Text)).ToString();
                    break;
                case "*":
                    resultBar.Text = (val * Double.Parse(resultBar.Text)).ToString();
                    break;
                case "/":
                    resultBar.Text = (val / Double.Parse(resultBar.Text)).ToString();
                    break;
                case "%":
                    resultBar.Text = (val % Double.Parse(resultBar.Text)).ToString();
                    break;
                default: break;
            }
            op_pressed = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(resultBar.Text);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                resultBar.Text = sr.ReadToEnd();
            }
            
        }
    }
}
