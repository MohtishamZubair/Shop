using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class DeliverableView
    {

        public int DeliverableId { get; set; }
        public int? InvoiceId { get; set; }
        public int AddressId { get; set; }        
        public string AgentId { get; set; }
        public DateTime DeliveryTime { get; set; }        
        public string Status { get; set; }
        public string Notes { get; set; }        
    }
}