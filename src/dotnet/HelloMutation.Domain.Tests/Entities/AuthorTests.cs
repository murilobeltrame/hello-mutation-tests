using HelloMutation.Domain.Entities;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class AuthorTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            var firstName = "Jhon";
            var lastName = "Doe";

            var author = new Author(firstName, lastName);
            
            Assert.Equal(firstName, author.FirstName);
            Assert.Equal(lastName, author.LastName);
        }
    }
}
