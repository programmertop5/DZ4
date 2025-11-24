using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dz4
{
    public class MyStudentException : Exception
    {
        public MyStudentException(string message) : base(message) { }
    }

    internal class Student
    {
        public string surname;
        public string name;
        public string parentname;
        public string group;
        public int age;
        public int[][]marks;
        public Student(string s, string n, string p, string g, int a)
        {
            this.surname = s;
            this.name = n;
            this.parentname = p;
            this.age = a;
            this.group = g;
            

            this.marks = new int[3][];
            this.marks[0] = new int[0];
            this.marks[1] = new int[0];
            this.marks[2] = new int[0];
        }
        public string Surname
        {
            get{ return surname;}
            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new MyStudentException("Прізвище не може бути порожнім!");
                }
                surname = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new MyStudentException("Ім'я не може бути порожнім!");
                name = value;
            }
        }

        public string Group
        {
            get { return group; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new MyStudentException("Група не може бути порожньою!");
                group = value;
            }
        }

        public string Parentname
        {
            get { return parentname; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new MyStudentException("По батькові не може бути порожнім!");
                parentname = value;
            }
        }


        public void SetMarks(int subject, int[] newMarks)
        {
            marks[subject] = newMarks;
        }
        public int GetMark(int subject,int index)
        {
            return marks[subject][index];
        }

        public double GetAverage(int subject)
        {
            if (marks[subject].Length == 0) return 0;
            double sum = 0;
            for(int i = 0;i < marks[subject].Length; i++)
            {
                sum = sum + marks[subject][i];
            }
            return sum / (double)marks[subject].Length;
        }
        
        public void Print()
        {
            Console.WriteLine("Student: {0} {1} {2} {3} {4}",name,surname,parentname,group,age);
            Console.Write("Programming: ");
            for (int i = 0; i < marks[0].Length; i++)
            {
                Console.Write(marks[0][i] + " ");
            }
            Console.WriteLine();
            Console.Write("Administration: ");
            for (int i = 0; i < marks[1].Length; i++)
            {
                Console.Write(marks[1][i] + " ");
            }
            Console.WriteLine();

            Console.Write("Design: ");
            for (int i = 0; i < marks[2].Length; i++)
            {
                Console.Write(marks[2][i] + " ");
            }
            Console.WriteLine();


        }
    }
}
