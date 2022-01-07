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
            Console.WriteLine($"The lowest grade is {result.low:N2}");
            Console.WriteLine($"The highest grade is {result.high:N2}");
            Console.WriteLine($"The average grade is {result.average:N2}");
            Console.WriteLine($"The letter grade is {result.letter}");
        }
    };
};
