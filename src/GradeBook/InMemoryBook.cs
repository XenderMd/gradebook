using System;
using System.Collections.Generic;

namespace GradeBook {

        
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook: Book{

        private List<double> grades;

        public override event GradeAddedDelegate GradeAdded;
        
        public InMemoryBook(string name):base(name) {
            grades = new List<double>();
        }

        public override void AddGrade(double grade){
            if(grade<=100 && grade>=0){
                grades.Add(grade);
                if(GradeAdded!=null){
                    GradeAdded(this, new EventArgs());
                };
            } else {
                Console.WriteLine("Invalid grade value");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            };
        }

        public void AddGrade(char letter){
            switch(letter){
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                case 'F':
                    AddGrade(40);
                    break;
                default:
                    AddGrade(0);
                    break;
            };
        }
        
        public override Statistics CalculateStatistics(){

            Statistics result = new Statistics();

            foreach(var grade in grades){
                result.Add(grade);
            };

            return result;
        }
    };

};