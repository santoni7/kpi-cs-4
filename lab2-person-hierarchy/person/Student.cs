using System;
namespace Lab2 {
    class Student : Person {
        private string group;
        private DateTime yearOfAdmission;

        public string Group { get => group; set => group = value; }
        public DateTime YearOfAdmission { get => yearOfAdmission; set => yearOfAdmission = value.Date; }
        public Student(string name, DateTime birthDate, University university) 
            : base(name, birthDate, university) {

        }

        public Student(string name, DateTime birthDate, University university, string group, DateTime yearOfAdmission) 
            : base(name, birthDate, university){
                this.group = group;
                this.yearOfAdmission = yearOfAdmission;
        }

        public void Exclude(){
            university.Students.Remove(this);
        }
        public override string ClassName(){
            return "Student";
        }

        public override string ToString(){
            return base.ToString() + "\n\tGroup: " + group + "\t Year of admission: " + yearOfAdmission.Year;
        }
    }
}