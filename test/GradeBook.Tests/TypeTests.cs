using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int count = 0;
        private InMemoryBook GetBook(string name){
            return new InMemoryBook(name);
        }

        private void GetBookSetName(InMemoryBook book, string name){
            book = new InMemoryBook(name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name){
            book = new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string name){
            book.Name=name;
        }

        private int GetInt(){
            return 3;
        }

        private void SetInt(ref int x){
            x=42;
        }

        private string MakeUppercase(string parameter){
            return parameter.ToUpper();
        }

        private string ReturnMessage(string message){
            count++;
            return message;
        }

        private string IncrementCount(string message){
            count++;
            return message.ToLower();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           //Arrange
           var book1=GetBook("Book 1");
           var book2=GetBook("Book 2");

           //Act
               
            //Assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject(){
            //Arrange
            var book1=GetBook("Book 1");
            var book2=book1;

            //Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
           //Arrange
           var book1=GetBook("Book 1");
           
           //Act
            SetName(book1, "New Name");
               
            //Assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
           //Arrange
           var book1=GetBook("Book 1");
           
           //Act
            GetBookSetName(book1, "New Name");
               
            //Assert
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
          public void CSharpCanPassByRef()
        {
           //Arrange
           var book1=GetBook("Book 1");
           
           //Act
            GetBookSetName(ref book1, "New Name");
               
            //Assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void Test1(){
            
            //Arrange
            var x = GetInt();
            
            //Assert
            Assert.Equal(3, x);

            SetInt(ref x);
            
            //Assert
            Assert.Equal(42, x);

        }

        [Fact]
        public void StringsBehaveLikeValueTypes(){
            
            //Arrange
            string name = "Denis";

            //Act
            string upper = MakeUppercase(name);

            //Assert
            Assert.Equal("Denis", name);
            Assert.Equal("DENIS", upper);
        }

        [Fact]
        public void WriteLogDelegateCanPointToMethod(){
            WriteLogDelegate log = ReturnMessage;
            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Hello");

            // Assert.Equal("Hello", result);
            Assert.Equal(3, count);
        }
    }
};
