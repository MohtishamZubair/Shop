namespace Shop.Models
{
    using System;

    public class BaseEntity
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        //should throw all deleted into archive separate db
        public bool IsDeleted { get; set; }
    }
}