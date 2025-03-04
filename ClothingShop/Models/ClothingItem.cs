using ClothingShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 1,000.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public ClothingSize Size { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public ClothingGender Gender { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
