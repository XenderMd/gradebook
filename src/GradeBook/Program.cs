using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Denis's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            var result = book.CalculateStatistics();
            Console.WriteLine($"The lowest grade is {result.low}");
            Console.WriteLine($"The highest grade is {result.high}");
            Console.WriteLine($"The average grade is {result.average}");
        }
    };
};
