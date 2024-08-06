namespace Shared.DTOs
{
    public record BaseEntityDto
    {
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
