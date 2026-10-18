using ERegistration.Models;
using ERegistration.Models.Repositories;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using System.IO.Pipelines;

namespace ERegistration.Controllers
{
    public class ContractorController : Controller
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly ILogger<ContractorController> _logger;
        public ContractorController(IContractorRepository contractorRepository, ILookupValueRepository lookupValueRepository, ILogger<ContractorController> logger)
        {
            _contractorRepository = contractorRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewData["Title"] = "Add Contractor";

                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                var businessTypes = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectBusinessTypes = new SelectList(businessTypes.Where(p => p.Entity == "BusinessTypes"), "Id", "Name", null);

                ContractorAddViewModel contractorAddViewModel = new() { BusinessTypes = selectBusinessTypes, States = selectStates };                
                return View(contractorAddViewModel);                
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new ContractorAddViewModel());

        }


        [HttpPost]
        public async Task<IActionResult> Add(ContractorAddViewModel contractorAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    Contractor contractor = new()
                    {
                        FirstName = contractorAddViewModel.Contractor.FirstName,
                        MiddleName = contractorAddViewModel.Contractor.MiddleName,
                        LastName = contractorAddViewModel.Contractor.LastName,
                        BusinessName = contractorAddViewModel.Contractor.BusinessName,
                        BusinessTypeId = contractorAddViewModel.SelectedBusinessTypeId,
                        BusinessTrade = contractorAddViewModel.Contractor.BusinessTrade,
                        LicenseNumber = contractorAddViewModel.Contractor.LicenseNumber,
                        BusinessId = contractorAddViewModel.Contractor.BusinessId,
                        ContactName = contractorAddViewModel.Contractor.ContactName,

                        //Address = new Address { Line1 = contractorAddViewModel.Contractor.Address.Line1,
                        //    Line2 = contractorAddViewModel.Contractor.Address.Line2,
                        //    City = contractorAddViewModel.Contractor.Address.City,
                        //    StateId = contractorAddViewModel.Contractor.Address.StateId,
                        //    ZipCode = contractorAddViewModel.Contractor.Address.ZipCode
                        //},
                        //MailingAddress = new Address
                        //{
                        //    Line1 = contractorAddViewModel.Contractor.MailingAddress.Line1,
                        //    Line2 = contractorAddViewModel.Contractor.MailingAddress.Line2,
                        //    City = contractorAddViewModel.Contractor.MailingAddress.City,
                        //    StateId = contractorAddViewModel.Contractor.MailingAddress.StateId,
                        //    ZipCode = contractorAddViewModel.Contractor.MailingAddress.ZipCode
                        //},

                        Address_Line1 = contractorAddViewModel.Contractor.Address_Line1,
                        Address_Line2 = contractorAddViewModel.Contractor.Address_Line2,
                        Address_City = contractorAddViewModel.Contractor.Address_City,
                        Address_StateId = contractorAddViewModel.Contractor.Address_StateId,
                        Address_ZipCode = contractorAddViewModel.Contractor.Address_ZipCode,
                        MailingAddress_Line1 = contractorAddViewModel.Contractor.MailingAddress_Line1,
                        MailingAddress_Line2 = contractorAddViewModel.Contractor.MailingAddress_Line2,
                        MailingAddress_City = contractorAddViewModel.Contractor.MailingAddress_City,
                        MailingAddress_StateId = contractorAddViewModel.Contractor.MailingAddress_StateId,
                        MailingAddress_ZipCode = contractorAddViewModel.Contractor.MailingAddress_ZipCode,
                        OfficePhone = contractorAddViewModel.Contractor.OfficePhone,
                        CellPhone = contractorAddViewModel.Contractor.CellPhone,                                      
                        Email = contractorAddViewModel.Contractor.Email,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedBy = 1,
                        LastUpdatedDate = DateTime.Now
                    };

                    await _contractorRepository.AddContractorAsync(contractor);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }            
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the contractor failed, please try again! Error: {ex.Message}");
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            contractorAddViewModel.States = selectStates;

            var businessTypes = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectListItems = new SelectList(businessTypes, "Id", "Name", null);
            contractorAddViewModel.BusinessTypes = selectListItems;

            return View(contractorAddViewModel);
        }
    }
}
