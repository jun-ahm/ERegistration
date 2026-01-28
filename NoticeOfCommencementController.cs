using ERegistration.Models;
using ERegistration.Models.Repositories;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace ERegistration.Controllers
{
    public class NoticeOfCommencementController : Controller
    {
        private readonly ILogger<NoticeOfCommencementController> _logger;
        private readonly IContractorRepository _contractorRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;

        //private readonly ERegistrationDbContext _eRegistrationDbContext;


        public NoticeOfCommencementController(IContractorRepository contractorRepository, IProjectRepository projectRepository, IPropertyOwnerRepository propertyOwnerRepository, ILogger<NoticeOfCommencementController> logger)
        {
            _projectRepository = projectRepository;
            _contractorRepository = contractorRepository;
            _propertyOwnerRepository = propertyOwnerRepository;
            _logger = logger;
        }

        [HttpPost]
        //public async Task<IActionResult> Create(NoticeOfCommencementViewModel nocAddViewModel)
        public Task<IActionResult> Create(NoticeOfCommencementViewModel nocAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //Contractor contractor = new()
                    //{
                    //    FirstName = nocAddViewModel.Contractor.FirstName,
                    //    MiddleName = nocAddViewModel.Contractor.MiddleName,
                    //    LastName = nocAddViewModel.Contractor.LastName,
                    //    BusinessName = nocAddViewModel.Contractor.BusinessName,
                    //    BusinessTypeId = nocAddViewModel.SelectedBusinessTypeId,
                    //    Address_Line1 = nocAddViewModel.Contractor.Address_Line1,
                    //    Address_Line2 = nocAddViewModel.Contractor.Address_Line2,
                    //    Address_City = nocAddViewModel.Contractor.Address_City,
                    //    Address_State = nocAddViewModel.Contractor.Address_State,
                    //    Address_ZipCode = nocAddViewModel.Contractor.Address_ZipCode,
                    //    MailingAddress_Line1 = nocAddViewModel.Contractor.MailingAddress_Line1,
                    //    MailingAddress_Line2 = nocAddViewModel.Contractor.MailingAddress_Line2,
                    //    MailingAddress_City = nocAddViewModel.Contractor.MailingAddress_City,
                    //    MailingAddress_State = nocAddViewModel.Contractor.MailingAddress_State,
                    //    MailingAddress_ZipCode = nocAddViewModel.Contractor.MailingAddress_ZipCode,                        
                    //    Email = nocAddViewModel.Contractor.Email
                    //};

                    //await _contractorRepository.AddContractorAsync(contractor);
                    //return RedirectToAction(nameof(Index));
                    return null;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the contractor failed, please try again! Error: {ex.Message}");
            }

            //var businessTypes = await _contractorRepository.GetBusinessTypesAsync();

            //IEnumerable<SelectListItem> selectListItems = new SelectList(businessTypes, "Id", "Name");            
            //nocAddViewModel.BusinessType = selectListItems;

            return null;

        }

        public IActionResult AddPropertyOwner()
        {
            return ViewComponent("SelectPropertyOwner");
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new NoticeOfCommencementViewModel();
                        
            var contractors = await _contractorRepository.GetAllContractorsAsync();
            viewModel.Contractors = new SelectList(contractors, "Id", "FullName");

            var projects = await _projectRepository.GetAllProjectsAsync();
            viewModel.Projects = new SelectList(projects, "Id", "ProjectName");

            //var propertyOwners = await _propertyOwnerRepository.GetAllPropertyOwnersAsync();
            //viewModel.PropertyOwners = new SelectList(propertyOwners, "Id", "Name");

            return View(viewModel);                        
        }



    }
}
