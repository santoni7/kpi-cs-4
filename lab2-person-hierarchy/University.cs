using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2 {
    class University{
        private string naming;
        private string city;

        private List<Student> students;
        private List<Enrollee> enrollees;
        private List<Lecturer> lecturers;

        public string Naming { get => naming; }
        public string City { get => city; }

        public List<Student> Students { get => students; }

        public List<Enrollee> Enrollees { get => enrollees; }

        public List<Lecturer> Lecturers { get => lecturers; }

        public HashSet<Person> AllPeople { get => 
            students.OfType<Person>()
                .Union(enrollees).Union(lecturers).ToHashSet();
        }

        public List<Student> StudentsFromGroup(string group){
            return students.Where(s => s.Group == group).ToList();
        }

        public Dictionary<string, Student> StudentsByGroup { get =>
            students.ToDictionary(s => s.Group);
        }

        public Person FindByName(string name) {
            return AllPeople.First(p => p.FullName.IndexOf(name) > -1);
        }

        public int TotalCount { get => students.Count + enrollees.Count + lecturers.Count; }

        public University(string naming, string city){
            this.naming = naming;
            this.city = city;
            this.students = new List<Student>();
            this.lecturers = new List<Lecturer>();
            this.enrollees = new List<Enrollee>();
        }


        public void PrintToConsole(){
            Console.WriteLine("University " + naming + ", Located at " + city);
            Console.WriteLine("\nLecturers: ");
            lecturers.ForEach(l => Console.WriteLine(l.ToString()));

            Console.WriteLine("\nStudents: ");
            students.ForEach(s => Console.WriteLine(s.ToString()));

            Console.WriteLine("\nEnrollees: ");
            enrollees.ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}