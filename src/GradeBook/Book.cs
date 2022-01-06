using System;
using System.Collections.Generic;

namespace GradeBook {

      public class Book{

        private List<double> grades;

        public string Name;
        
        public Book(string name){
            Name = name;
            grades = new List<double>();
        }

        public void AddGrade(double grade){
            grades.Add(grade);
        }
        
        public Statistics CalculateStatistics(){

            Statistics result = new Statistics();

            foreach(var grade in grades){
                result.high = Math.Max(result.high, grade);
                result.low = Math.Min(result.low, grade);
                result.average +=grade; 
            };

            result.average/=grades.Count;

            return result;
        }
    };

};