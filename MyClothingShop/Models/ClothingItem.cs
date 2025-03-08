using MyClothingShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyClothingShop.Models
{
    public class ClothingItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        [EnumDataType(typeof(Size))]
        public Size Size { get; set; }

    }
}
