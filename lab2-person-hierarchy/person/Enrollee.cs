using System;

namespace Lab2 {
    class Enrollee : Person {
        private int testsScore;

        public int TestsScore { get => testsScore; set => testsScore = value; }

        public Enrollee(string name, DateTime birthDate, University university) 
            : base(name, birthDate, university) {

        }

        public Enrollee(string name, DateTime birthDate, University university, int testsScore) 
            : base(name, birthDate, university) {
            this.testsScore = testsScore;
        }

        public override string ClassName(){
            return "Enrollee";
        }

        public Student MakeAStudent(string group, DateTime yearOfAdmission){
            Student s = new Student(fullName, birthDate, university, group, yearOfAdmission);
            university.Enrollees.Remove(this);
            university.Students.Add(s);
            return s;
        }

        public override string ToString()
        {
            return base.ToString() + "\n\tTests score: " + testsScore;
        }
    }
}