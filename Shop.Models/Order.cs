using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey("OrderRef")]
        public int? OrderRefId { get; set; }
        public string ShopUserId { get; set; }
        public decimal OrderAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public bool IsPartial { get; set; }
        public string OrderNotes { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual ShopUser ShopUser { get; set; }
        public virtual Order OrderRef { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}