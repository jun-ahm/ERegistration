using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class ContractorAddViewModel
    {
        public IEnumerable<SelectListItem>? BusinessTypes { get; set; } = default!;
        public int? SelectBusinessTypeId { get; set; }
        public IEnumerable<SelectListItem>? States { get; set; } = default!;
        public int SelectedStateId { get; set; }
        public Contractor Contractor { get; set; }
        
    }
}