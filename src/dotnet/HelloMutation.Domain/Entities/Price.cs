using System;

namespace HelloMutation.Domain.Entities
{
    public record Price
    {
        public Price(decimal value, DateTime startingAt) => (Value, StartingAt) = (value, startingAt);

        public DateTime StartingAt { get; }
        public decimal Value { get; }
    }
}