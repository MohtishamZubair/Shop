
namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ProductView
    {
        public int Id { get; set; }

       [Required]
        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }


        public string CategoryName { get; set; }


        [Required]
        [Display(Name = "Product Name")]
        [MaxLength(200, ErrorMessage = "The {0} must not be more than 200 characters.")]
        public string Name { get; set; }
        
        [Display(Name = "Model Number")]
        [MaxLength(200, ErrorMessage = "The {0} must not be more than 200 characters.")]
        public string ModelNumber { get; set; }

        [Display(Name = "Model Name")]
        [MaxLength(200, ErrorMessage = "The {0} must not be more than 200 characters.")]
        public string ModelName { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Retail Price")]
        public decimal MRP { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        // Form Properties
                    
        public string Title { get; set; }
        public string ActionOfForm { get; set; }
        public string ActionHeading { get; set; }
        public string SubmitAction { get; set; }


        internal void SetProductForm( string FormTitle, string FormAction, string FormActionHeading, string FormSubmitText)
        {
            this.Title = FormTitle;
            this.ActionOfForm = FormAction;
            this.ActionHeading = FormActionHeading;
            this.SubmitAction = FormSubmitText;
        }

    }
}