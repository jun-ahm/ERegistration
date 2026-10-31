using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERegistration.ViewModels
{
    public class NoticeOfCommencementViewModel
    {
        public IEnumerable<SelectListItem>? Contractors { get; set; } = default!
        [Display(Name = "Contractor")]
        public int SelectedContractorId { get; set; }
        [Display(Name = "Project")]
        public int SelectedProjectId { get; set; }
        public IEnumerable<SelectListItem>? Projects { get; set; } = default!
        [Display(Name = "Property Owner")]
        public IList<int> SelectedPropertyOwnerId { get; set; } = default!
        public IEnumerable<SelectListItem>? Lenders { get; set; } = default!
        [Display(Name = "Lender")]
        public int SelectedLenderId { get; set; }
        public IEnumerable<SelectListItem>? TitleCompanies { get; set; } = default!
        [Display(Name = "TitleCompany")]
        public int SelectedTitleCompanyId { get; set; }
    }
}