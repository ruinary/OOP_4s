using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class FormSort : System.Windows.Forms.Form
    {
        public FormSort()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                Results.result.Clear();
                Results.result.AddRange(Form1.studentListControl.studentList.OrderBy(n => n.Course));
                Results formRes = new Results();
                formRes.Show();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Results.result.Clear();
                Results.result.AddRange(Form1.studentListControl.studentList.OrderBy(n => n.Group));
                Results formRes = new Results();
                formRes.Show();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }
    }
}
