using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Foreign keys and navigation properties
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
}
