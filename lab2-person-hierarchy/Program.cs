using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, DateTime> makeYear = (y) => new DateTime(y, 1, 1);
            Func<int, int, int, DateTime> makeDate = (y, m, d) => new DateTime(y, m, d);

            University university = new UniversityBuilder("KPI", "Kyiv")
                .AddLecturer("Lishcuk K. I.", makeDate(1990, 3, 14), "Docent", new string[]{"IP-62", "IP-61"})
                .AddLecturer("Boldak A. O.", makeDate(1983, 7, 1), "Docent", new string[]{"IP-62", "IP-61"})
                .AddLecturer("Novatarsky M. A.", makeDate(1975,1,1), "Professor", new string[]{"IP-62"})

                .AddStudent("Sakhniuk A. U.", makeDate(1998, 6, 2), "IP-62", makeYear(2016))
                .AddStudent("Satochi Nakamoto", makeDate(1999, 1, 1), "IP-62", makeYear(2016))
                .AddStudent("Elon Musk", makeDate(1997, 1, 1), "IP-61", makeYear(2016))
                .AddStudent("Charlie Lee", makeDate(1999, 9, 1), "IP-61", makeYear(2016))

                .AddEnrollee("Roger Ver", makeDate(2000, 1, 1), 195)
                .AddEnrollee("Queen Elizabeth II", makeDate(2001, 1, 1), 200)
                .AddEnrollee("Donald Trump", makeDate(2003, 1, 1), 173)
                .Build();

            university.PrintToConsole();

            university.Enrollees.Where(e => e.TestsScore > 190)
                .ToList().ForEach(e => e.MakeAStudent("IP-72", DateTime.Now));
            
            Console.WriteLine("------------------------------");
            university.PrintToConsole();

            var novatarsky = university.FindByName("Novatarsky") as Lecturer;
            novatarsky?.Fire();

            Console.WriteLine("------------------------------");
            university.PrintToConsole();
        }
    }
}
