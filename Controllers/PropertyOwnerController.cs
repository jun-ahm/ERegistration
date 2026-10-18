using ERegistration.Models;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.Controllers
{
    public class PropertyOwnerController : Controller
    {
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly ILogger<PropertyOwnerController> _logger;
        public PropertyOwnerController(IPropertyOwnerRepository propertyOwnerRepository, ILookupValueRepository lookupValueRepository, ILogger<PropertyOwnerController> logger)
        {
            _propertyOwnerRepository = propertyOwnerRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewData["Title"] = "Add PropertyOwner";
                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                var propertyOwners = await _propertyOwnerRepository.GetAllPropertyOwnersAsync();
                IEnumerable<SelectListItem> selectPropertyOwners = new SelectList(propertyOwners, "Id", "Name");

                PropertyOwnerAddViewModel propertyOwnerAddViewModel = new() { States = selectStates };
                return View(propertyOwnerAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new PropertyOwnerAddViewModel());

        }


        [HttpPost]
        public async Task<IActionResult> Add(PropertyOwnerAddViewModel propertyOwnerAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PropertyOwner propertyOwner = new()
                    {
                        FirstName = propertyOwnerAddViewModel.PropertyOwner.FirstName,
                        MiddleName = propertyOwnerAddViewModel.PropertyOwner.MiddleName,
                        LastName = propertyOwnerAddViewModel.PropertyOwner.LastName,                        
                        Address_Line1 = propertyOwnerAddViewModel.PropertyOwner.Address_Line1,
                        Address_Line2 = propertyOwnerAddViewModel.PropertyOwner.Address_Line2,
                        Address_City = propertyOwnerAddViewModel.PropertyOwner.Address_City,
                        Address_StateId = propertyOwnerAddViewModel.PropertyOwner.Address_StateId,
                        Address_ZipCode = propertyOwnerAddViewModel.PropertyOwner.Address_ZipCode,
                        County = propertyOwnerAddViewModel.PropertyOwner.County,
                        MailingAddress_Line1 = propertyOwnerAddViewModel.PropertyOwner.MailingAddress_Line1,
                        MailingAddress_Line2 = propertyOwnerAddViewModel.PropertyOwner.MailingAddress_Line2,
                        MailingAddress_City = propertyOwnerAddViewModel.PropertyOwner.MailingAddress_City,
                        MailingAddress_StateId = propertyOwnerAddViewModel.PropertyOwner.MailingAddress_StateId,
                        MailingAddress_ZipCode = propertyOwnerAddViewModel.PropertyOwner.MailingAddress_ZipCode,
                        Phone = propertyOwnerAddViewModel.PropertyOwner.Phone,
                        Fax = propertyOwnerAddViewModel.PropertyOwner.Fax,
                        Email = propertyOwnerAddViewModel.PropertyOwner.Email,
                        CreatedBy = 1,
                        LastUpdatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                    };

                    await _propertyOwnerRepository.AddPropertyOwnerAsync(propertyOwner);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the PropertyOwner failed, please try again! Error: {ex.Message}");
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            
            propertyOwnerAddViewModel.States = selectStates;

            return View(propertyOwnerAddViewModel);
        }
    }
}
