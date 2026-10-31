using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class LenderAddViewModel
    {
        public Lender Lender { get; set; }
        public IEnumerable<SelectListItem>? States { get; set; } = default!;        
    }
}