using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERegistration.ViewModels
{
    public class ProjectEditViewModel
    {
        public int Id { get; set; }
        public string County { get; set; }
        [Display(Name = "Number")]
        public string? Address_Line1 { get; set; }
        [Display(Name = "Street Name")]
        public string? Address_Line2 { get; set; }
        [Display(Name = "Suite/Apt Number")]
        public string? Address_Line3 { get; set; }
        [Display(Name = "City")]
        public string? Address_City { get; set; }
        public int? Address_StateId { get; set; }
        public IEnumerable<SelectListItem>? Address_State { get; set; }
        [Display(Name = "Zip Code")]
        public string? Address_ZipCode { get; set; }
        public string TaxParcel { get; set; }
        public string LegalDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}