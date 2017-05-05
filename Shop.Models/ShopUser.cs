using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class ShopUser
    {
        [ScaffoldColumn(false)]  
        [Key,ForeignKey("ApplicationUser")]
        [StringLength(128)]     
        public string ShopUserId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }

        [Display(Name = "Office Number")]
        public string OfficeNumber { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Miscelleneous Information")]
        public string MiscelleneousInfo { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public UserTypeEnum UserType { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual IList<Address> Addresses { get; set; }
    }
}