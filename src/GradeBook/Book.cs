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
            if(grade<=100 && grade>=0){
                grades.Add(grade);
            } else {
                Console.WriteLine("Invalid grade value");
            }
        }

        public void AddLetterGrade(char letter){
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
        
        public Statistics CalculateStatistics(){

            Statistics result = new Statistics();

            foreach(var grade in grades){
                result.high = Math.Max(result.high, grade);
                result.low = Math.Min(result.low, grade);
                result.average +=grade; 
            };

            result.average/=grades.Count;

            switch(result.average){
                case var d when d>=90.0:
                    result.letter='A';
                    break;
                case var d when d>=80.0:
                    result.letter='B';
                    break;
                case var d when d>=70.0:
                    result.letter='C';
                    break;
                case var d when d>=60.0:
                    result.letter='D';
                    break;
                default:
                    result.letter='F';
                    break;
            }

            return result;
        }
    };

};