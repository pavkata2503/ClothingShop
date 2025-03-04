using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1,000.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Order is required.")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required(ErrorMessage = "Clothing Item is required.")]
        public int ClothingItemId { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
}
