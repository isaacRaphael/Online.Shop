

using CartApp.Models.Base;

namespace CartApp.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CartId { get; set; }

    }
}
