using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop.Models
{
    public class UserView
    {      
        [ScaffoldColumn(false)]  
        public string UserId { get; set; }

        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Display(Name = "Role")]
        public string UserRole { get; set; }
        //public IEnumerable<SelectListItem> UserRoles { get; set; }
        public List<CheckBoxListItem> UserRoles { get; set; }

    }
}