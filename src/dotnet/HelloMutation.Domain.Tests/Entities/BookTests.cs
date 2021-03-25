using HelloMutation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace HelloMutation.Domain.Tests.Entities
{
    public class BookTests
    {
        private static readonly string _validTitle = "Book Title";
        private static readonly IEnumerable<Author> _mockedAuthors = new Author[] { new Author("John", "Doe") };
        private static readonly Publisher _mockedPublisher = new Publisher("Publishers House");

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

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_title_should_throw_an_ArgumentNullException()
        {
            static void act() => new Book(null, _mockedAuthors, _mockedPublisher);
            var exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal(nameof(Book.Title), exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_least_one_Author_should_throw_an_ArgumentException()
        {
            static void act() => new Book(_validTitle, null, _mockedPublisher);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(nameof(Book.Authors), exception.ParamName);
        }

        [Fact]
        [SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "Should test exception while trying to instantiate de object.")]
        public void Book_without_a_Publisher_should_throw_an_ArgumentException()
        {
            static void act() => new Book(_validTitle, _mockedAuthors, null);
            var exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(nameof(Book.Publisher), exception.ParamName);
        }

        // PRICING

        [Fact]
        public void Setting_Price_should_accumulate_Price_record()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice, expectedDate);
            Assert.Contains(book.Pricing, (price) =>
                price.Value == expectedPrice &&
                price.StartingAt == expectedDate);
        }

        [Fact]
        public void Setting_Price_without_Date_should_add_a_price_with_current_Date()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice);
            Assert.Contains(book.Pricing, (price) =>
                price.Value == expectedPrice &&
                price.StartingAt.Date == expectedDate.Date);
        }

        [Fact]
        public void Getting_Price_at_exact_Date_should_return_the_Price()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice - 5, expectedDate.AddDays(-20));
            book.SetPrice(expectedPrice, expectedDate);
            book.SetPrice(expectedPrice + 5, expectedDate.AddDays(20));
            var _result = book.GetPriceAt(expectedDate);
            Assert.Equal(expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_in_inverval_should_return_the_oldest_Price()
        {
            var expectedPrice = 10m;
            var expectedDate = DateTime.Now;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.SetPrice(expectedPrice + 5, expectedDate.AddDays(20));
            book.SetPrice(expectedPrice, expectedDate);
            book.SetPrice(expectedPrice - 5, expectedDate.AddDays(-20));
            var _result = book.GetPriceAt(expectedDate.AddDays(10));
            Assert.Equal(expectedPrice, _result.Value);
        }

        [Fact]
        public void Getting_Price_for_an_unset_Price_history_should_return_value_0_for_Today()
        {
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            var result = book.GetPriceAt(DateTime.Now);
            Assert.Equal(0m, result.Value);
        }

        // RATING

        [Theory]
        //[InlineData(3, "Not so good rate.")]
        [InlineData(5, "Excelent rate.")]
        public void Review_should_be_instantiated(ushort rating, string note)
        {
            var expectedRating = rating;
            var expectedNote = note;
            var review = new Review(rating, note);
            Assert.Equal(expectedRating, review.Rating);
            Assert.Equal(expectedNote, review.Note);
        }

        [Fact]
        public void Placing_Review_greater_than_5_should_thrown_ArgumentOutOfRangeException()
        {
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            void act() => book.PlaceReview(6);
            Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal(0, book.Reviews.Count);
        }

        [Fact]
        public void Getting_average_rating_should_be_the_Reviews_raging_average()
        {
            ushort? expectedRating = 2;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            book.PlaceReview(3);
            book.PlaceReview(1);
            var result = book.GetAverageRating();
            Assert.Equal(expectedRating, result);
        }

        [Fact]
        public void Getting_average_rating_for_an_unset_Review_history_should_return_Null()
        {
            ushort? expectedRating = null;
            var book = new Book(_validTitle, _mockedAuthors, _mockedPublisher);
            var result = book.GetAverageRating();
            Assert.Equal(expectedRating, result);
        }
    }
}
