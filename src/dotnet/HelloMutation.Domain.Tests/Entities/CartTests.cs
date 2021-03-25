using HelloMutation.Domain.Entities;
using System;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class CartTests
    {
        private static readonly Guid _validSessionId = Guid.NewGuid();
        private static readonly DateTime _validDate = DateTime.Now;
        private static readonly Book _mockedBook = new Book(
            "A book",
            new Author[] {
                new Author("Jhon", "Doe")
            },
            new Publisher("The Publisher")
        );

        [Fact]
        public void Should_Be_Instantiated()
        {
            var sessionId = Guid.NewGuid();
            var createdAt = DateTime.Now;

            var cart = new Cart(sessionId, createdAt);

            Assert.Equal(sessionId, cart.SessionId);
            Assert.Equal(createdAt, cart.CreatedAt);
        }

        #region ADDING ITEMS

        [Fact]
        public void Adding_an_item_for_cart_should_create_a_record()
        {
            ushort expectedQuantity = 1;
            var expectedBookPrice = _mockedBook.GetPriceAt(DateTime.Now).Value;
            var cart = new Cart(_validSessionId, _validDate);
            cart.AddItem(_mockedBook, expectedQuantity);
            Assert.Contains(cart.Items, (item) =>
                item.Book == _mockedBook &&
                item.Price == expectedBookPrice &&
                item.Quantity == expectedQuantity);
        }

        [Fact]
        public void Adding_an_item_twice_in_a_cart_should_accumulate_the_same_record()
        {
            ushort expectedQuantity = 2;
            var expectedBookPrice = _mockedBook.GetPriceAt(DateTime.Now).Value;
            var cart = new Cart(_validSessionId, _validDate);
            cart.AddItem(_mockedBook, 1);
            cart.AddItem(_mockedBook, 1);
            Assert.Contains(cart.Items, (item) =>
                item.Book == _mockedBook &&
                item.Price == expectedBookPrice &&
                item.Quantity == expectedQuantity);
        }

        [Fact]
        public void Adding_item_of_unset_book_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "book";
            var cart = new Cart(_validSessionId, _validDate);
            void act() => cart.AddItem(null, 1);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        #endregion

        #region UPDATE ITEM QUANTITY

        [Fact]
        public void Update_item_quantity_should_change_quantity()
        {
            ushort expectedQuantity = 3;
            var expectedBookPrice = _mockedBook.GetPriceAt(DateTime.Now).Value;
            var cart = new Cart(_validSessionId, _validDate);
            cart.AddItem(_mockedBook, 1);
            cart.UpdateItemQuantity(_mockedBook.Title, expectedQuantity);
            Assert.Contains(cart.Items, (item) =>
                item.Book == _mockedBook &&
                item.Price == expectedBookPrice &&
                item.Quantity == expectedQuantity);

        }

        [Fact]
        public void Update_item_without_a_book_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "bookTitle";
            var cart = new Cart(_validSessionId, _validDate);
            void act() => cart.UpdateItemQuantity(null, 1);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        public void Update_an_unexisting_item_should_thrown_ArgumenteException()
        {
            var expectedExceptionFieldName = "bookTitle";
            var cart = new Cart(_validSessionId, _validDate);
            void act() => cart.UpdateItemQuantity("Unexisting Book", 3);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        #endregion

        #region REMOVE ITEM

        [Fact]
        public void Remove_an_item_should_wipe_record_from_items()
        {
            var cart = new Cart(_validSessionId, _validDate);
            cart.AddItem(_mockedBook, 10);
            cart.RemoveItem(_mockedBook.Title);
            Assert.DoesNotContain(cart.Items, (item) =>
                item.Book == _mockedBook);
        }

        [Fact]
        public void Remove_an_unset_item_should_thrown_ArgumentNullException()
        {
            var expectedExceptionFieldName = "bookTitle";
            var cart = new Cart(_validSessionId, _validDate);
            void act() => cart.RemoveItem(null);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        [Fact]
        public void Remove_an_unexisting_item_should_thrown_ArgumentException()
        {
            var expectedExceptionFieldName = "bookTitle";
            var cart = new Cart(_validSessionId, _validDate);
            void act() => cart.RemoveItem("Unexisting Book");
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedExceptionFieldName, exception.ParamName);
        }

        #endregion

        #region CHECKOUT

        [Fact]
        public void Should_be_possible_to_Checkout()
        {
            var cart = new Cart(_validSessionId, _validDate);
            cart.Checkout();
            Assert.True(cart.CheckedOut);
        }

        #endregion
    }
}
