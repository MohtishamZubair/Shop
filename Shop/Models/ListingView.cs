namespace Shop.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ListingView
    {
        [ScaffoldColumn(false)]
        public int ProductListingId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Display(Name ="Name of Product")]
        public string ProductName { get; set; }
        /// <summary>
        /// we can utilize this for open market for buyer/customer also.
        /// </summary>
        public string ShopUserId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public QuantityTypeEnum QuantityType { get; set; }

        public int PerQuantityType { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public int UnitPrice { get; set; }

        [Display(Name = "Discount Quantity")]
        public int DiscountQuantity { get; set; }

        [Display(Name = "Discount Rate")]
        public decimal DiscountPercent { get; set; }

        public decimal Weight { get; set; }
        
        public virtual Product Product { get; set; }
    }
}