using System;

namespace HelloMutation.Domain.Entities
{
    public record CartItem
    {
        public CartItem(
            Book book,
            ushort quantity
        ) => (Book, Price, Quantity) = (book, book.GetPriceAt(DateTime.Now).Value, quantity);

        private Book _book;
        public Book Book
        {
            get => _book;
            init => _book = value ?? throw new ArgumentNullException(nameof(Book));
        }
        public decimal Price { get; }
        public ushort Quantity { get; }
    }
}
