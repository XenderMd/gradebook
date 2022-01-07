using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName;
           
            Console.WriteLine("Please enter the name of your new book");
            bookName = Console.ReadLine();

            // var book = new InMemoryBook(bookName);
            var book = new DiskBook(bookName);
            book.GradeAdded += onGradeAdded;

            EnterGrades(book);

            var result = book.CalculateStatistics();
            Console.WriteLine($"The statistics for the book \"{book.Name}\" are:");
            Console.WriteLine($"The lowest grade is {result.low:N2}");
            Console.WriteLine($"The highest grade is {result.high:N2}");
            Console.WriteLine($"The average grade is {result.average:N2}");
            Console.WriteLine($"The letter grade is {result.letter}");
        }

        private static void EnterGrades(IBook book)
        {
            double grade = 0.0;
            string input = "s";

            while (input != "q")
            {
                Console.WriteLine("Please enter your next grade");
                input = Console.ReadLine();
                if (input != "q")
                {
                    try
                    {
                        grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    };
                };
            };
        }

        static void onGradeAdded(object sender, EventArgs e){
            Console.WriteLine("A grade was added");
        }
    }
};
