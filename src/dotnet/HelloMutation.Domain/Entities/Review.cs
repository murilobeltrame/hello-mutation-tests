using System;

namespace HelloMutation.Domain.Entities
{
    public record Review
    {
        public Review(ushort rating, string note) => (Rating, Note) = (rating, note);

        private ushort _rating;
        public ushort Rating
        {
            get => _rating;
            init => _rating = value <= 5 ? value : throw new ArgumentOutOfRangeException(nameof(Rating));
        }
        public string Note { get; }
    }
}