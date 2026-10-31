using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERegistration.ViewModels
{
    public class TitleCompanyEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Business Name")]
        public string Name { get; set; }
        [Display(Name = "Number")]
        public string? Address_Line1 { get; set; }
        [Display(Name = "Street Name")]
        public string? Address_Line2 { get; set; }
        [Display(Name = "City")]
        public string? Address_City { get; set; }
        public int? Address_StateId { get; set; }
        public IEnumerable<SelectListItem>? Address_State { get; set; }
        [Display(Name = "Zip Code")]
        public string? Address_ZipCode { get; set; }
        [Display(Name = "Office Phone")]
        public string? OfficePhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string? CellPhone { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}