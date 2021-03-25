using HelloMutation.Domain.Entities;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class CartItemTests
    {
        [Fact]
        public void Should_Be_Instantiated()
        {
            ushort quantity = 1;
            var price = 1.00m;
            var book = new Book(
                "The Book",
                new[] { new Author("Jhon", "Doe") },
                new Publisher("The Publisher")
            );
            book.SetPrice(price);

            var cartItem = new CartItem(book, quantity);

            Assert.Equal(quantity, cartItem.Quantity);
            Assert.Equal(price, cartItem.Price);
        }
    }
}
