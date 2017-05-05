using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        
        public int ProductId { get; set; }

        [Required]
        public int Name { get; set; }
        [Required]
        public int Value { get; set; }
        
        public virtual Product Product { get; set; }

    }
}