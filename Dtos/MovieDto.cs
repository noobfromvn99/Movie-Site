using System;
namespace Movies.Dtos
{
    public record MovieDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}