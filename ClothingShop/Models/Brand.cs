using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<ClothingItem> ClothingItems { get; set; }
    }
}
