
using CartApp.Models.Base;

namespace CartApp.Models
{
    public class ShoppingCart : BaseEntity
    {
        public int Status { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
