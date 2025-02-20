using ClothingShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } // URL for the item's image

        // Enum properties
        public ClothingSize Size { get; set; }
        public ClothingGender Gender { get; set; }

        // Foreign keys and navigation properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
