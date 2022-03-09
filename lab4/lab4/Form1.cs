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
    public partial class Form1 : Form
    {
        Timer timer;
        DateTime thisDate = DateTime.Now;

        List<Student> studentList = new List<Student>();

        public static StudentListChangeControl studentListControl = new StudentListChangeControl();
        public static CaretakerStudentList caretaker = new CaretakerStudentList();
        public static CaretakerStudentList caretakerTurnBack = new CaretakerStudentList();

        void timer_Tick(object sender, EventArgs e)
        {
            dateandtime.Text = DateTime.Now.ToLongDateString()+" ";
            dateandtime.Text += DateTime.Now.ToLongTimeString();
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            notes.Text = dataGridView1.Rows.Count.ToString();
            notes.Text += " запись(ей)";
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            notes.Text = dataGridView1.Rows.Count.ToString();
            notes.Text += " запись(ей)";
        }
        public Form1()
        {
            InitializeComponent();
            dateBD.MaxDate = thisDate.AddYears(-15);

            caretaker.History.Push(studentListControl.SaveState());

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void EnableButton()
        {
            //button1.Enabled = ((bool)fio.Tag && (bool)city.Tag && (bool)street.Tag && (bool)housenum.Tag && (bool)apartnum.Tag && (bool)index.Tag);
            if ((bool)fio.Tag && (bool)city.Tag && (bool)street.Tag && (bool)housenum.Tag && (bool)index.Tag && (bool)apartnum.Tag)
            {
                button1.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fio.Tag = false;
            city.Tag = false;
            street.Tag = false;
            housenum.Tag = false;
            apartnum.Tag = false;
            index.Tag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".xml$"))
            {
                xmlSerialization.Serialize(studentListControl.studentList, filename);
                doing.Text = "Сохранение в XML файл";
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".xml$"))
            {

                studentListControl.studentList = xmlSerialization.Deserialize<List<Student>>(filename);
                dataGridView1.Rows.Clear();
                foreach (Student x in studentListControl.studentList)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Crs"].Value = x.Course;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Grp"].Value = x.Group;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["GNDR"].Value = x.Sex;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["SPC"].Value = x.Profession;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Agee"].Value = x.Age;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Com"].Value = x.company;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["TYPEOFSTUDENT"].Value = x.exam;
                }
                caretaker.History.Push(studentListControl.SaveState());
                doing.Text = "Добавлена информация из XML файла";
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void dateBD_ValueChanged(object sender, EventArgs e)
        {

            age.Text = (thisDate.Year - dateBD.Value.Year).ToString();
        }
        private void AddToTable(Student student)
        {
            student.exam.TakeExam();
            studentList.Add(student);
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = student.FullName;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Crs"].Value = student.Course;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Grp"].Value = student.Group;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = student.AverageGrade;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = student.Birthday;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["GNDR"].Value = student.Sex;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["SPC"].Value = student.Profession;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Agee"].Value = student.Age;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = student.adress;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Com"].Value = student.company;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["TYPEOFSTUDENT"].Value = student.exam;

            fio.Clear();
            sex.SelectedIndex = 0;
            dateBD.Value = thisDate.AddYears(-15);

            spec.ResetText();
            course.ResetText();
            group.ResetText();
            avgrade.ResetText();

            city.Clear();
            street.Clear();
            housenum.Clear();
            apartnum.Clear();
            index.Clear();

            company.Clear();
            grade.Clear();
            exp.ResetText();

            fio.Tag = false;
            city.Tag = false;
            street.Tag = false;
            housenum.Tag = false;
            apartnum.Tag = false;
            index.Tag = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (StF.Text == "Заочная")
            {
                Student student = new Student(
                       fio.Text,//ФИО
                       age.Text,//Возраст
                       spec.Text,//Профессия
                       dateBD.Value.ToString(),//Дата рождения
                       course.Text,//курс
                       group.Text,//группа
                       avgrade.Value,//средняя
                       sex.Text,//пол
                       new Adress(city.Text, index.Text, street.Text, int.Parse(housenum.Text), int.Parse(apartnum.Text)),
                       new Company(company.Text, exp.Value, grade.Text), 
                       new ExtramuralStudentFactory()
                       );
                
                AddToTable(student);
            }
            if (StF.Text == "Очная")
            {
                Student student = new Student(
                       fio.Text,//ФИО
                       age.Text,//Возраст
                       spec.Text,//Профессия
                       dateBD.Value.ToString(),//Дата рождения
                       course.Text,//курс
                       group.Text,//группа
                       avgrade.Value,//средняя
                       sex.Text,//пол
                       new Adress(city.Text, index.Text, street.Text, int.Parse(housenum.Text), int.Parse(apartnum.Text)),
                       new Company(company.Text, exp.Value, grade.Text), 
                       new IntramuralStudentFactory()
                       );
                
                AddToTable(student);
            }
            

            doing.Text = "Запись добавлена в таблицу";

            EnableButton();
        }
        //--------------------------------------------------------------------------------------------------------//
        private void fio_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(fio.Text, @"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$"))
            {
                fio.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                fio.Tag = false;
            }
            else
            {
                fio.BackColor = Color.White;
                fio.Tag = true;
            }
            EnableButton();
        }

        private void city_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(city.Text, @"[А-Я][а-я]+$"))
            {
                city.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                city.Tag = false;
            }
            else
            {
                city.BackColor = Color.White;
                city.Tag = true;
            }
            EnableButton();
        }

        private void street_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(street.Text, @"(([А-Я][а-я]+(\s?))+$)|([А-Я][а-я]+(-?)([А-Я]?)([а-я]+)$)"))
            {
                street.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                street.Tag = false;
            }
            else
            {
                street.BackColor = Color.White;
                street.Tag = true;
            }
            EnableButton();
        }

        private void housenum_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(housenum.Text, @"[1-9][0-9]*[а-я]*$"))
            {
                housenum.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                housenum.Tag = false;
            }
            else
            {
                housenum.BackColor = Color.White;
                housenum.Tag = true;
            }
            EnableButton();
        }

        private void apartnum_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(apartnum.Text, @"[1-9][0-9]*$"))
            {
                apartnum.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                apartnum.Tag = false;
            }
            else
            {
                apartnum.BackColor = Color.White;
                apartnum.Tag = true;
            }
            EnableButton();
        }

        private void index_V(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(index.Text, @"^[1-9][0-9]{5}$"))
            {
                index.BackColor = ColorTranslator.FromHtml("#ff8d8d");
                index.Tag = false;
            }
            else
            {
                index.BackColor = Color.White;
                index.Tag = true;
            }
            EnableButton();
        }
        //--------------------------------------------------------------------------------------------------------//
        private void icon_search_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 )
            {
                lab3.FormSearch form1 = new FormSearch();
                form1.Show();
                doing.Text = "Открыто меню поиска";
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
}

        private void icon_sort_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                lab3.FormSort form2 = new FormSort();
                form2.Show();
                doing.Text = "Открыто меню сортировки";
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void icon_del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                caretaker.History.Push(studentListControl.SaveState());
                studentListControl.studentList.Clear();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{//string FN, string AGE, string PRF, string BDAY, string CRS, string GRP, decimal AVG, string SEX, Adress ADRS, Company COM
                //    studentListControl.studentList.Add(
                //       new Student(
                //       (string)dataGridView1.Rows[i].Cells["NSL"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Agee"].Value,
                //       (string)dataGridView1.Rows[i].Cells["SPC"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Birth"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Crs"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Grp"].Value,
                //       (decimal)dataGridView1.Rows[i].Cells["Avg"].Value,
                //       (string)dataGridView1.Rows[i].Cells["GNDR"].Value,
                //       (Adress)dataGridView1.Rows[i].Cells["Adr"].Value,
                //       (Company)dataGridView1.Rows[i].Cells["Com"].Value));
                //}
                doing.Text = "Удалена одна запись";
            }
        }
        private void icon_clear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                caretaker.History.Push(studentListControl.SaveState());
                studentListControl.studentList.Clear();
                dataGridView1.Rows.Clear();
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    studentListControl.studentList.Add(
                //       new Student(
                //       (string)dataGridView1.Rows[i].Cells["NSL"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Agee"].Value,
                //       (string)dataGridView1.Rows[i].Cells["SPC"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Birth"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Crs"].Value,
                //       (string)dataGridView1.Rows[i].Cells["Grp"].Value,
                //       (decimal)dataGridView1.Rows[i].Cells["Avg"].Value,
                //       (string)dataGridView1.Rows[i].Cells["GNDR"].Value,
                //       (Adress)dataGridView1.Rows[i].Cells["Adr"].Value,
                //       (Company)dataGridView1.Rows[i].Cells["Com"].Value));
                //}
                doing.Text = "Таблица очищена";
            }
        }
        //--------------------------------------------------------------------------------------------------------//
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Цвет фона: {Form1.DefaultBackColor} \nВерсия приложения: v1.0", "О приложении");
        }

        private void стильОкнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingletonForm1 info = SingletonForm1.getInstance(this.BackColor, this.Font, this.Size);
            MessageBox.Show(info.ToString(),"Стиль окна");
        }
        private void оСтудентеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells["NSL"].Value.ToString();
                Student findout = new Student();
                foreach (Student x in studentListControl.studentList)
                {
                    if (x.FullName == name)
                    {
                        findout = x;
                    }
                }
                StudentDirector studentInfo = new StudentDirector();
                PrivateInformationBuilder studentPrivateInfoBuilder = new PrivateInformationBuilder();
                string outInfo = studentInfo.BuildString(studentPrivateInfoBuilder, findout).ToString();
                MessageBox.Show(outInfo, "Результат запроса");
            }
        }

        private void обАдресеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells["NSL"].Value.ToString();
                Student findout = new Student();
                foreach (Student x in studentListControl.studentList)
                {
                    if (x.FullName == name)
                    {
                        findout = x;
                    }
                }
                StudentDirector studentInfo = new StudentDirector();
                AdressInformationBuilder studentAdressInfoBuilder = new AdressInformationBuilder();
                string outInfo = studentInfo.BuildString(studentAdressInfoBuilder, findout).ToString();
                MessageBox.Show(outInfo, "Результат запроса");
            }
        }
        private void оКомпанииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells["NSL"].Value.ToString();
                Student findout = new Student();
                foreach (Student x in studentListControl.studentList)
                {
                    if (x.FullName == name)
                    {
                        findout = x;
                    }
                }
                StudentDirector studentInfo = new StudentDirector();
                CompanyInformationBuilder studentCompanyInfoBuilder = new CompanyInformationBuilder();
                string outInfo = studentInfo.BuildString(studentCompanyInfoBuilder, findout).ToString();
                MessageBox.Show(outInfo, "Результат запроса");
            }
        }
        private void оГруппеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = dataGridView1.SelectedRows[0].Cells["NSL"].Value.ToString();
                Student findout = new Student();
                foreach (Student x in studentListControl.studentList)
                {
                    if (x.FullName == name)
                    {
                        findout = x;
                    }
                }
                StudentDirector studentInfo = new StudentDirector();
                GroupInformationBuilder studentGroupInfoBuilder = new GroupInformationBuilder();
                string outInfo = studentInfo.BuildString(studentGroupInfoBuilder, findout).ToString();
                MessageBox.Show(outInfo, "Результат запроса");
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Ничего не выбрано!", "Ошибка!"); }
            catch (NullReferenceException) { MessageBox.Show("Коллекция записей пуста!", "Ошибка!"); }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Results.result.Count != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                if (Regex.IsMatch(filename, $".xml$"))
                {
                    xmlSerialization.Serialize(Results.result, filename);
                    doing.Text = "Результат сортировки или поиска сохранён в файл";

                }
                else
                {
                    MessageBox.Show("Неверный формат файла!");
                }
            }
            else
            {
                MessageBox.Show("Сохраняемая коллекция записей пуста!", "Сохранение результатов");
            }
        }

        private void стажToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void группаToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void стажToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Results.result.Clear();
                Results.result.AddRange(Form1.studentListControl.studentList.OrderBy(n => n.company.exp));
                Results formRes = new Results();
                formRes.Show();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void поФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                FormSearchFIO form21 = new FormSearchFIO();
                form21.Show();
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void поСреднемуБаллуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                FormSearchAvrGrade form24 = new FormSearchAvrGrade();
                form24.Show();
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void поСпециальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                FormSearchSpec form22 = new FormSearchSpec();
                form22.Show();
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void поКурсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                FormSearchCourse form23 = new FormSearchCourse();
                form23.Show();
            }
            else
            {
                MessageBox.Show("Коллекция записей пуста!", "Ошибка!");
            }
        }

        private void icon_prev_Click(object sender, EventArgs e)
        {
            if (caretaker.History.Count != 0)
            {
                caretakerTurnBack.History.Push(studentListControl.SaveState());
                studentListControl.RestoreState(caretaker.History.Pop());
                dataGridView1.Rows.Clear();
                if (studentListControl.studentList != null)
                {
                    foreach (Student x in studentListControl.studentList)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Crs"].Value = x.Course;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Grp"].Value = x.Group;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["GNDR"].Value = x.Sex;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["SPC"].Value = x.Profession;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Agee"].Value = x.Age;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Com"].Value = x.company;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["TYPEOFSTUDENT"].Value = x.exam;
                    }
                }
                doing.Text = "Возврат к предыдущему действию";
            }
        }

        private void icon_next_Click(object sender, EventArgs e)
        {
            if (caretakerTurnBack.History.Count != 0)
            {
                caretaker.History.Push(studentListControl.SaveState());
                studentListControl.RestoreState(caretakerTurnBack.History.Pop());
                dataGridView1.Rows.Clear();
                if (studentListControl.studentList != null)
                {
                    foreach (Student x in studentListControl.studentList)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["NSL"].Value = x.FullName;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Crs"].Value = x.Course;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Grp"].Value = x.Group;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Avg"].Value = x.AverageGrade;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Birth"].Value = x.Birthday;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["GNDR"].Value = x.Sex;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["SPC"].Value = x.Profession;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Agee"].Value = x.Age;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Adr"].Value = x.adress;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Com"].Value = x.company;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["TYPEOFSTUDENT"].Value = x.exam;
                    }
                }
                doing.Text = "Отмена возврата к предыдущему действию";
            }
        }

        //--------------------------------------------------------------------------------------------------------//
    }
}
