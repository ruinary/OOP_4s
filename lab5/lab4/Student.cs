using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3
{
    [Serializable]
    [XmlRoot(Namespace = "STUDENTS")]
    [XmlType("student")]
    public class Student : StudentPrototype
    {
        public Student(string FN, string AGE, string PRF, string BDAY, string CRS, string GRP, decimal AVG, string SEX, Adress ADRS, Company COM, AbstractFactory factory)
        {
            FullName = FN;
            Age = AGE;
            Profession = PRF;
            Birthday = BDAY;
            Course = CRS;
            Group = GRP;
            AverageGrade = AVG;
            Sex = SEX;
            adress = ADRS;
            company = COM;
            exam = factory.CreateExam();
        }
        public Student(string FN, string AGE, string PRF, string BDAY, string CRS, string GRP, decimal AVG, string SEX, Adress ADRS, Company COM)
        {
            FullName = FN;
            Age = AGE;
            Profession = PRF;
            Birthday = BDAY;
            Course = CRS;
            Group = GRP;
            AverageGrade = AVG;
            Sex = SEX;
            adress = ADRS;
            company = COM;
        }
        public Student()
        {
            FullName = "";
            Age = "";
            Profession = "";
            Birthday = "";
            Course = "";
            Group = "";
            AverageGrade = 0;
            Sex = "";
            adress = new Adress();
            company = new Company();
        }

        [XmlElement(ElementName = "name")]
        [Required(ErrorMessage = "Значение ФИО должно быть задано", AllowEmptyStrings = false)]
        public string FullName;
        [XmlElement(ElementName = "age")]
        public string Age;
        [XmlElement(ElementName = "prof")]
        public string Profession;
        [XmlElement(ElementName = "birthday")]
        public string Birthday;
        [XmlElement(ElementName = "course")]
        public string Course;
        [XmlElement(ElementName = "group")]
        public string Group;
        [XmlElement(ElementName = "avgG")]
        [Range(0, 10, ErrorMessage = "Неверное значение среднего балла!")]
        public decimal AverageGrade;
        [XmlElement(ElementName = "sex")]
        public string Sex;
        [XmlElement(ElementName = "adress")]
        public Adress adress;
        [XmlElement(ElementName = "company")]
        public Company company;
        public Exam exam;

        public void TakingExam()
        {
            exam.TakeExam();
        }

        public override StudentPrototype Clone()
        {
            if (this.exam.typeOfStudent == "Заочник")
            {
                return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress,company, new ExtramuralStudentFactory());
            }
            else if (this.exam.typeOfStudent == "Очник")
            {
                return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress, company, new IntramuralStudentFactory());
            }
            return new Student(FullName, Age, Profession, Birthday, Course, Group, AverageGrade, Sex, adress, company);
        }

        public Student(AbstractFactory factory)
        {
            exam = factory.CreateExam();
        }
    }
}