using System;
using System.Collections.Generic;
using System.Linq;

namespace HW3._3FINAL
{
    class Program
    {
        public static void DefaultData(ref Dictionary<string, List<Student>> dictionary)
        {
            Student s1 = new Student("Horbachenko", 1995);
            Student s2 = new Student("Hanoshenko", 2001);
            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);
            string key1 = "TV21";
            dictionary.Add(key1, students);
        }

        public static void DisplayDictionary(ref string _groupName, Dictionary<string, List<Student>> dictionary)
        {


            foreach (var item in dictionary)
            {
                if (_groupName == item.Key)
                {
                    foreach (var test in item.Value)
                    {
                        Console.Write(test.Surname + ":" + test.YearOfBirth + " ");
                    }
                }
            }

            Console.WriteLine();

        }

        public static bool CheckDictionary(ref string _groupName, ref Dictionary<string, List<Student>> dictionary)
        {
            var isPresent = false;
            
            foreach (var item in dictionary)
            {
                
                if (_groupName == item.Key)
                {
                    isPresent = true;
                }
                else
                {
                    isPresent = false;
                }
            }

            return isPresent;


        }


       
        public static List<Student> AddStudent()
        {
            List<Student> students = new List<Student>();
            string surname;
            int yearOfBirth;
            var isStudentInputFinished = true;
             
            
            while (isStudentInputFinished)
            {
                try
                {
                    Console.WriteLine("Please enter students in format 'Surname1:YearOfBirth1, Surname2:YearOfBirth2'");

                    //Console.WriteLine("Or enter 'exit' to exit");
                    string temp1 = Console.ReadLine();

                    string[] mixSurnameAndYears = temp1.Split(new char[] { ':' });
                    surname = mixSurnameAndYears[0];
                    yearOfBirth = Convert.ToInt32(mixSurnameAndYears[1]);

                    students.Add(new Student(surname, yearOfBirth));

                    Console.WriteLine("Students added");
                    Console.WriteLine("Enter 'submit' to stop input or 'continue' to continue input");

                    temp1 = Console.ReadLine();
                    if (temp1 == "submit")
                    {
                        isStudentInputFinished = false;
                        break;
                    }
                    else if (temp1 == "continue")
                    {
                        continue;
                    }
                }
                catch(System.IndexOutOfRangeException e1){
                    Console.WriteLine("Wrong input. Try again");
                }
            }
            

            return students;



        

            
        }

    public static void Start(ref string _groupName)
    {
            var students = new List<Student>();
            var dictionary = new Dictionary<string, List<Student>>();
            DefaultData(ref dictionary);
            if (CheckDictionary(ref _groupName, ref dictionary) == true)
            {
                DisplayDictionary(ref _groupName, dictionary);
            }
            else
            {
                Console.WriteLine($"There are no group with {_groupName} code. Do you want to add it? (y/n)");
                string _answer = Console.ReadLine();
                if (_answer == "y" || _answer == "Y")
                {
                    students = AddStudent();


                }
                else if (_answer == "n" || _answer == "N")
                {

                }
                dictionary.Add(_groupName, students);
            }

            DisplayDictionary(ref _groupName, dictionary);




    }
        

        static void Main(string[] args)
        {
            var b = true;
            while (b)
            {
                Console.WriteLine("Please enter group code. Enter 'exit' to exit:");
                string _groupName = Console.ReadLine();

                Start(ref _groupName);
            }
            

        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    class Student
    {
        private string surname;
        private int yearOfBirth;

        public Student() { }

        public Student(string surname, int yearOfBirth)
        {
            this.surname = surname;
            this.yearOfBirth = yearOfBirth;
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine(Surname + ":" + YearOfBirth);
        }
    }
}