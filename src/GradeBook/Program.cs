using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.AddGrade(15.5);

            var grades = new List<double>(){12.7, 10.3, 6.11}; 
            var gradesNum = grades.Count;
            double result = 0.0;
    
            foreach(double number in grades){
                result+=number;
            };
            result/=gradesNum;

            Console.WriteLine($"Your average grade is {result:N3}");
        }
    };
};
