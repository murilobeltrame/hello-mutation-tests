using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloMutation.Domain.Entities
{
    public record Book
    {
        public Book(
            string title,
            IEnumerable<Author> authors,
            Publisher publisher,
            ushort? pages = null
        ) => (Title, Authors, Publisher, Pages) = (title, authors, publisher, pages);

        private IEnumerable<Author> _authors;
        public IEnumerable<Author> Authors
        {
            get => _authors;
            init => _authors = (value?.Any()).GetValueOrDefault() ? value : throw new ArgumentException("", nameof(Authors));
        }

        private Publisher _publisher;
        public Publisher Publisher
        {
            get => _publisher;
            init => _publisher = value ?? throw new ArgumentException("", nameof(Publisher));
        }

        private string _title;
        public string Title
        {
            get => _title;
            init => _title = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(nameof(Title));
        }

        public ushort? Pages { get; }
        public IList<Review> Reviews { get; } = new List<Review>();
        public IList<Price> Pricing { get; } = new List<Price>();

        public void SetPrice(decimal value, DateTime? startingAt = null) => Pricing.Add(new Price(value, startingAt ?? DateTime.Now));

        public Price GetPriceAt(DateTime date) => Pricing
            .OrderByDescending(price => price.StartingAt)
            .FirstOrDefault(price => price.StartingAt <= date) ?? new Price(0m, DateTime.Now);

        public void PlaceReview(ushort rating, string note = null) => Reviews.Add(new Review(rating, note));

        public ushort? GetAverageRating() => Reviews.Any() ? (ushort?)Reviews.Average(review => review.Rating) : null;
    }
}
