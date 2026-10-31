using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERegistration.ViewModels
{
    public class ContractorEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Business Name")]
        public string? BusinessName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }      
        public string LicenseNumber { get; set; }
        [Display(Name = "Number")]
        public string? Address_Line1 { get; set; }
        [Display(Name = "Street Name")]
        public string? Address_Line2 { get; set; }
        [Display(Name = "Suite/Apt Number")]
        public string? Address_Line3 { get; set; }
        [Display(Name = "City")]
        public string? Address_City { get; set; }
        public int Address_StateId { get; set; }
        public IEnumerable<SelectListItem>? Address_State { get; set; }
        [Display(Name = "Zip Code")]
        public string? Address_ZipCode { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string CellPhone { get; set; }        
    }
}