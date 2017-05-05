using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ModelNumber { get; set; }

        [StringLength(200)]
        public string ModelName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required]
        public decimal MRP { get; set; }

        public virtual IList<ProductAttribute> ProductAttributes { get; set; }
        public virtual IList<ProductImage> ProductImages { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<ProductListing> ProductListings { get; set; }
    }
}