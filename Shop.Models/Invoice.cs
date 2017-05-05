namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Invoice : BaseEntity
    {
        [ScaffoldColumn(false)]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceRef")]
        public int? InvoiceRefId { get; set; }
        public int OrderId { get; set; }
        public decimal InvoiceAmount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Invoice InvoiceRef { get; set; }
    }
}