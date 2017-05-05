namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class CategoryView
    {
        public CategoryView()
        {       
        }        
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(200)]
        public string Name { get; set; }
                
        [Display(Name = "Sub Category Of ")]
        public int? SubCategoryId { get; set; }


        public string SubCategoryName { get; set; }
    }
}