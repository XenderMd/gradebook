using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
           //Arrange
           var book = new InMemoryBook("");
           book.AddGrade(89.1);
           book.AddGrade(90.5);
           book.AddGrade(77.3);

           //Act
           var result = book.CalculateStatistics();
            
            //Assert
            Assert.Equal(77.3, result.low, 1);
            Assert.Equal(90.5, result.high, 1);
            Assert.Equal(85.6, result.average, 1);
            Assert.Equal('B', result.letter);
        }
    }
};
