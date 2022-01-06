using System;
using System.Collections.Generic;

namespace GradeBook {

      class Book{

        private List<double> grades;
        private string name;
        private double highGrade;
        private double lowGrade;

        public Book(string name){
            this.name = name;
            grades = new List<double>();
            highGrade=double.MinValue;
            lowGrade=double.MaxValue;
        }

        public void AddGrade(double grade){
            grades.Add(grade);
        }
        
        public void ShowStatistics(){
            CalculateStatistics();
            Console.WriteLine($"The lowest grade is {lowGrade:N3}");
            Console.WriteLine($"The highest grade is {highGrade:N3}");
        }

        private void CalculateStatistics(){
            foreach(var grade in grades){
                highGrade = Math.Max(highGrade, grade);
                lowGrade=Math.Min(lowGrade, grade);
            };
        }
    };

};