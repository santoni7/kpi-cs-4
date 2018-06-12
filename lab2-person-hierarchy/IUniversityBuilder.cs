using System;

namespace Lab2 {
    interface IUniversityBuilder{
        IUniversityBuilder AddStudent(string name, DateTime birthDate, string group, DateTime year);
        IUniversityBuilder AddLecturer(string name, DateTime birthDate, string degree);
        IUniversityBuilder AddLecturer(string name, DateTime birthDate, string degree, string[] groups);
        IUniversityBuilder AddEnrollee(string name, DateTime birthDate, int score);
        University Build();
    }
}