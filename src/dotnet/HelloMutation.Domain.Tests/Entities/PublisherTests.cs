using HelloMutation.Domain.Entities;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class PublisherTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            var name = "The Publisher";

            var publisher = new Publisher(name);

            Assert.Equal(name, publisher.Name);
        }
    }
}
