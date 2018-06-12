using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab2 {
    class Lecturer : Person {
        private List<string> groups;
        private string degree;

        public List<string> Groups { get => groups; }
        public string Degree { get => degree; set => degree = value; }

        public Lecturer(string name, DateTime birthDate, University university) 
            : base(name, birthDate, university) {
                this.degree = "Assistant";
                groups = new List<string>();
        }

        public Lecturer(string name, DateTime birthDate, University university, string degree)
            : base(name, birthDate, university){
                this.degree = degree;
                this.groups = new List<string>();
        }

        public void Fire(){
            university.Lecturers.Remove(this);
        }

        public override string ClassName(){
            return "Lecturer";
        }

        public override string ToString(){
            return base.ToString() + "\n\tDegree: " + degree + "\n\tGroups: " + String.Join(", ", groups);
        }
    }
}