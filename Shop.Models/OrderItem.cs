
namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        [ScaffoldColumn(false)]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductListingId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal OtherAmount { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductListing ProductListing { get; set; }

    }
}