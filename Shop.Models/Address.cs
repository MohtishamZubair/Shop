using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Address
    {

        [ScaffoldColumn(false)]
        public int AddressId { get; set; }
        [ScaffoldColumn(false)]
        public string ShopUserId { get; set; }
        [Required]
        [Display(Name="House / Unit / Aparatment No")]
        public string HouseNo { get; set; }

        [Required]
        [Display(Name = "Street No.")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }

        public double LatLocation { get; set; }
        public double LongLocation { get; set; }


        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Address Type")]
        public AddressTypeEnum AddressType { get; set; }
        public virtual ShopUser User { get; set; }
    }
}