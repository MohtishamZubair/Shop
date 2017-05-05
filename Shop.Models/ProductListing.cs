using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    /// <summary>
    /// Inventory for product
    /// </summary>
    public class ProductListing : BaseEntity 
    {
        
        public int ProductListingId { get; set; }

        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// we can utilize this for open market for buyer/customer also.
        /// </summary>
        [Required]
        public string ShopUserId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public QuantityTypeEnum QuantityType { get; set; }

        public int PerQuantityType { get; set; }

        [Required]     
        public int UnitPrice { get; set; }
        
        public int DiscountQuantity { get; set; }

        public decimal DiscountPercent { get; set; }
        
        public decimal Weight { get; set; }

        public virtual ShopUser Market_Seller { get; set; }
        public virtual Product Product { get; set; }
    }
}