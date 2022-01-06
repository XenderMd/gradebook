using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
           //Arrange
           var book = new Book("");
           book.AddGrade(89.1);
           book.AddGrade(90.5);
           book.AddGrade(77.3);

           //Act
           var result = book.CalculateStatistics();
            
            //Assert
            Assert.Equal(result.low, 77.3, 1);
            Assert.Equal(result.high, 90.5, 1);
            Assert.Equal(result.average, 85.6, 1);
         
        }
    }
};
