using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class ProjectAddViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<SelectListItem>? States { get; set; } = default!;
        public IEnumerable<SelectListItem>? ProjectTypes { get; set; } = default!;
        public IEnumerable<SelectListItem>? ProjectSubTypes1 { get; set; } = default!;
        public IEnumerable<SelectListItem>? ProjectSubTypes2 { get; set; } = default!;
    }
}