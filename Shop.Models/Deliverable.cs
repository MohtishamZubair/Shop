namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Deliverable : BaseEntity
    {
        public int DeliverableId { get; set; }
        public int? InvoiceId { get; set; }
        public int? AddressId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public DateTime? DeliveryTime { get; set; }
        public DeliveryStatusEnum? Status { get; set; }
        public string Notes { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
    }
}