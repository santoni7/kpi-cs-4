using System;

namespace Lab2 {
    abstract class Person {
        protected string fullName;
        protected DateTime birthDate; 
        protected Guid id;
        protected University university;

        public string FullName { get => fullName; }

        public DateTime BirthDate { get => birthDate; }

        public Guid ID { get => id; }

        public University University { get => university; }

        public Person(string name, DateTime birthDate, University university){
            this.fullName = name;
            this.birthDate = birthDate.Date;
            id = Guid.NewGuid();
            this.university = university;
        }

        public int GetAge(){
            var now = DateTime.Now;
            int y = now.Year - birthDate.Year;
            if(now.Month == birthDate.Month && now.Day < birthDate.Day
                || now.Month < birthDate.Month){
                    y--;
            }
            return y;
        }
        
        public bool IsStudent { get => this is Student; }
        public bool IsEnrollee { get => this is Enrollee; }
        public bool IsLecturer { get => this is Lecturer; }

        public abstract string ClassName();
        public override string ToString(){ 
            return String.Format("{0} is {1}\n\tBirth date: {2}\tAge: {3}\n\tUniversity: {4} at {5}",
                fullName, ClassName(), birthDate.ToShortDateString(), GetAge(), university.Naming, university.City);
        }
    }
}