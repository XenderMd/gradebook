using System;
using System.IO;

namespace GradeBook {
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name){}

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (var writer = File.AppendText($"./{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    };
                };
            }else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override Statistics CalculateStatistics()
        {
            Statistics result = new Statistics();

            using (var reader = File.OpenText($"./{Name}.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var grade = double.Parse(reader.ReadLine());
                    result.Add(grade);
                }
            }
            return result;
        }
    }
}