using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<Category>();
        }
        
        public int CategoryId { get; set; }
        [ForeignKey("SubCategory")]
        public int? SubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
        public virtual Category SubCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}