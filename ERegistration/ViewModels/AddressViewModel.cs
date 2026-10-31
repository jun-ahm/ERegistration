using ERegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.ViewModels
{
    public class AddressViewModel
    {
        public Address Address { get; set; }
        public IEnumerable<SelectListItem>? States { get; set; } = default!;
    }
}