using HelloMutation.Domain.Entities;
using System;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class CartTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            var sessionId = Guid.NewGuid();
            var createdAt = DateTime.Now;

            var cart = new Cart(sessionId, createdAt);

            Assert.Equal(sessionId, cart.SessionId);
            Assert.Equal(createdAt, cart.CreatedAt);
        }
    }
}
