using ClothingShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total Amount is required.")]
        [Range(0.01, 100000, ErrorMessage = "Total Amount must be between 0.01 and 100,000.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public OrderStatus Status { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Navigation property for order items
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
