using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERegistration.ViewModels
{
    public class PropertyOwnerEditViewModel
    {
        public int PropertyOwnerId { get; set; }        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }        
        [Display(Name = "Address Line1")]
        public string Address_Line1 { get; set; }
        [Display(Name = "Address Line2")]
        public string? Address_Line2 { get; set; }
        [Display(Name = "City")]
        public string? Address_City { get; set; }
        public int? Address_StateId { get; set; }
        public IEnumerable<SelectListItem>? Address_State { get; set; }
        [Display(Name = "Zip Code")]
        public string Address_ZipCode { get; set; }
        public string Email { get; set; }        
        public string Phone { get; set; }
    }
}