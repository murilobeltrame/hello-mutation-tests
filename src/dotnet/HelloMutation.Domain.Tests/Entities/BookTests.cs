using HelloMutation.Domain.Entities;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class BookTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            var title = "The Book";
            var authorFirstName = "Jhon";
            var authorLastName = "Doe";
            var publisherName = "The Publisher";

            var book = new Book(
                title, 
                new[] { new Author(authorFirstName, authorLastName) },
                new Publisher(publisherName)
            );

            Assert.Equal(title, book.Title);
            Assert.Contains(book.Authors, author => author.FirstName == authorFirstName && author.LastName == authorLastName);
            Assert.Equal(publisherName, book.Publisher.Name);
        }
    }
}
