using System;

namespace Lab2 {
    class UniversityBuilder : IUniversityBuilder
    {
        private University u;
        public UniversityBuilder(string naming, string city){
            u = new University(naming, city);
        }

        public IUniversityBuilder AddEnrollee(string name, DateTime birthDate, int score)
        {
            u.Enrollees.Add(new Enrollee(name, birthDate, u, score));
            return this;
        }

        public IUniversityBuilder AddLecturer(string name, DateTime birthDate, string degree)
        {
            u.Lecturers.Add(new Lecturer(name, birthDate, u, degree));
            return this;
        }

        public IUniversityBuilder AddLecturer(string name, DateTime birthDate, string degree, string[] groups)
        {
            var l = new Lecturer(name, birthDate, u, degree);
            l.Groups.AddRange(groups);
            u.Lecturers.Add(l);
            return this;
        }

        public IUniversityBuilder AddStudent(string name, DateTime birthDate, string group, DateTime year)
        {
            u.Students.Add(new Student(name, birthDate, u, group, year));
            return this;
        }

        public University Build()
        {
            return u;
        }
    }
}