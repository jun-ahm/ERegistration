using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class TitleCompanyAddViewModel
    {
        public IEnumerable<SelectListItem>? States { get; set; } = default!;
        public TitleCompany TitleCompany { get; set; }

    }
}