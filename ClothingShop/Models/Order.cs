using ClothingShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Enum property
        public OrderStatus Status { get; set; }

        // Foreign key and navigation property
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Navigation property for order items
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
