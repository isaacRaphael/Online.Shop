namespace CartApp.DTOs.Incoming
{
    public record ProductDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string? ImageUrl { get; set; }
    }
}
