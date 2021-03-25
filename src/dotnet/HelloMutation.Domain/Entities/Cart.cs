using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloMutation.Domain.Entities
{
    public record Cart
    {
        public Cart(
            Guid sessionId,
            DateTime createdAt
        ) => (SessionId, CreatedAt) = (sessionId, createdAt);

        public DateTime CreatedAt { get; }
        public Guid SessionId { get; }
        public IList<CartItem> Items { get; } = new List<CartItem>();
        public bool CheckedOut { get; private set; } = false;
        public decimal TotalValue => Items.Sum(item => item.Price * item.Quantity);

        public void AddItem(Book book, ushort quantity)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            var item = GetCartItemByTitle(book.Title);
            if (item != null)
            {
                var index = Items.IndexOf(item);
                Items[index] = new CartItem(item.Book, (ushort)(item.Quantity + quantity));
                return;
            }
            Items.Add(new CartItem(book, quantity));
        }

        public void Checkout() => CheckedOut = true;

        public void RemoveItem(string bookTitle)
        {
            if (string.IsNullOrWhiteSpace(bookTitle)) throw new ArgumentNullException(nameof(bookTitle));
            var item = GetCartItemByTitle(bookTitle);
            if (item == null) throw new ArgumentException("", nameof(bookTitle));
            Items.Remove(item);
        }

        public void UpdateItemQuantity(string bookTitle, ushort newQuantity)
        {
            if (string.IsNullOrWhiteSpace(bookTitle)) throw new ArgumentNullException(nameof(bookTitle));
            var item = GetCartItemByTitle(bookTitle);
            if (item == null) throw new ArgumentException("", nameof(bookTitle));
            var index = Items.IndexOf(item);
            Items[index] = new CartItem(item.Book, newQuantity);
        }

        private CartItem GetCartItemByTitle(string title) => Items.FirstOrDefault(item => string.Compare(item.Book?.Title, title, StringComparison.InvariantCultureIgnoreCase) >= 0);
    }
}
