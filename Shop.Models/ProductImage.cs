using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ProductImage
    {
        [ScaffoldColumn(false)]
        public int ProductImageId { get; set; }

        [ScaffoldColumn(false)]
        public int ProductId { get; set; }


        [Required]
        public string ImagePath { get; set; }

        public virtual Product Product { get; set; }

    }
}