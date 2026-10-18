using System.ComponentModel.DataAnnotations;

namespace ERegistration.Models
{
    public class Address
    {

        [Display(Name = "Street Address")]
        public string Line1 { get; set; }

        [Display(Name = "Apt/Suite/Unit")]
        public string Line2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}