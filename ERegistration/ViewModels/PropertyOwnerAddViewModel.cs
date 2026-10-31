using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class PropertyOwnerAddViewModel
    {
        public IEnumerable<SelectListItem>? States { get; set; } = default!;
        public PropertyOwner PropertyOwner { get; set; }
        public int SelectedPropertyOwnerId { get; set; }
        public IEnumerable<SelectListItem>? PropertyOwners { get; set; } = default!;        
    }
}