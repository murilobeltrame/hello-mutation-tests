using HelloMutation.Domain.Entities;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class ReviewTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            ushort rating = 1;
            var note = "Nothing important";

            var review = new Review(rating, note);

            Assert.Equal(rating, review.Rating);
            Assert.Equal(note, review.Note);
        }
    }
}
