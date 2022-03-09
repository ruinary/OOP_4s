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
    public partial class FormSearch : System.Windows.Forms.Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSearchFIO form21 = new FormSearchFIO();
            form21.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSearchSpec form22 = new FormSearchSpec();
            form22.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSearchCourse form23 = new FormSearchCourse();
            form23.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSearchAvrGrade form24 = new FormSearchAvrGrade();
            form24.Show();
        }
    }
}
