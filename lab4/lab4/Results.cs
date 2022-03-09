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
    public partial class Results : System.Windows.Forms.Form
    {
        public static List<Student> result = new List<Student>();

        public Results()
        {
            InitializeComponent();
        }

        private void Results_Shown(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Student x in Results.result)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Crs"].Value = x.Course;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Grp"].Value = x.Group;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Agee"].Value = x.Age;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Com"].Value = x.company;
            }
        }
    }
}
