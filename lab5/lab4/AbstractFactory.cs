using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public abstract class AbstractFactory
    {
        public abstract Exam CreateExam();
    }

    public abstract class Exam
    {
        public string message = default;
        public string typeOfStudent = default;
        public abstract void TakeExam();
        public override string ToString()
        {
            return typeOfStudent + "(" + message + ")";
        }
    }

    class InUniversity : Exam
    {
        public override void TakeExam()
        {
            this.typeOfStudent = "Очная";
            this.message = "Экзамены - очно";
        }
    }
    class OnDistance: Exam
    {
        public override void TakeExam()
        {
            this.typeOfStudent = "Заочная";
            this.message = "Экзамены - дистанционно";
        }
    }
    class ExtramuralStudentFactory : AbstractFactory
    {
        public override Exam CreateExam()
        {
            return new OnDistance();
        }
    }
    class IntramuralStudentFactory : AbstractFactory
    {
        public override Exam CreateExam()
        {
            return new InUniversity();
        }
    }
}

