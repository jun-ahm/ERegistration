using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.Controllers
{
    public class AddressController : Controller
    {
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly ILogger<AddressController> _logger;
        public AddressController(ILookupValueRepository lookupValueRepository, ILogger<AddressController> logger)
        {            
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                AddressViewModel addressAddViewModel = new() { States = selectStates };
                return View(addressAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new AddressViewModel());
        }
    }
}
