using HelloMutation.Domain.Entities;
using System;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class PriceTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            var value = 1m;
            var startingAt = DateTime.Now;

            var price = new Price(value, startingAt);

            Assert.Equal(value, price.Value);
            Assert.Equal(startingAt, price.StartingAt);
        }
    }
}
