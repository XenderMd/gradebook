using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName;
            string input = "s";
            double grade = 0.0;

            Console.WriteLine("Please enter the name of your new book");
            bookName = Console.ReadLine();

            var book = new Book(bookName);

            while(input != "q"){
                Console.WriteLine("Please enter your next grade");
                input = Console.ReadLine();
                if(input!="q"){
                    try{
                        grade=double.Parse(input);
                        book.AddGrade(grade);
                    }catch(ArgumentException ex){
                        Console.WriteLine(ex.Message);
                    }catch(FormatException ex){
                        Console.WriteLine(ex.Message);
                    }finally{
                        Console.WriteLine("**");
                    };
                };
            };

            var result = book.CalculateStatistics();
            Console.WriteLine($"The lowest grade is {result.low:N2}");
            Console.WriteLine($"The highest grade is {result.high:N2}");
            Console.WriteLine($"The average grade is {result.average:N2}");
            Console.WriteLine($"The letter grade is {result.letter}");
        }
    };
};
