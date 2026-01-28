using ERegistration.Models;
using ERegistration.Models.Repositories;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ERegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;
        private readonly ILookupValueRepository _lookupValueRepository;
        public HomeController(IPropertyOwnerRepository propertyOwnerRepository, ILookupValueRepository lookupValueRepository, ILogger<HomeController> logger)
        {
            _propertyOwnerRepository = propertyOwnerRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewData["Title"] = "Home";
                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                var propertyOwners = await _propertyOwnerRepository.GetAllPropertyOwnersAsync();
                IEnumerable<SelectListItem> selectPropertyOwners = new SelectList(propertyOwners, "Id", "Name");

                PropertyOwnerAddViewModel propertyOwnerAddViewModel = new() { States = selectStates, PropertyOwners = selectPropertyOwners };
                return View(propertyOwnerAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new PropertyOwnerAddViewModel());            
            //return View();
        }        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
