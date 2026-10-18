using ERegistration.Models;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.Controllers
{
    public class TitleCompanyController : Controller
    {
        private readonly ITitleCompanyRepository _titleCompanyRepository;
        private readonly ILookupValueRepository _lookupValueRepository;
        private readonly ILogger<TitleCompanyController> _logger;

        public TitleCompanyController(ITitleCompanyRepository titleCompanyRepository, ILookupValueRepository lookupValueRepository, ILogger<TitleCompanyController> logger)
        {
            _titleCompanyRepository = titleCompanyRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var titleCompanies = await _titleCompanyRepository.GetAllTitleCompaniesAsync();
            return View(titleCompanies);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewData["Title"] = "Add Title Company";

                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                TitleCompanyAddViewModel titleCompanyAddViewModel = new() { States = selectStates };
                return View(titleCompanyAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new TitleCompanyAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TitleCompanyAddViewModel titleCompanyAddViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TitleCompany titleCompany = new()
                    {
                        Name = titleCompanyAddViewModel.Name,
                        FirstName = titleCompanyAddViewModel.FirstName,
                        MiddleName = titleCompanyAddViewModel.MiddleName,
                        LastName = titleCompanyAddViewModel.LastName,
                        Title = titleCompanyAddViewModel.Title,
                        Phone = titleCompanyAddViewModel.Phone,
                        CellPhone = titleCompanyAddViewModel.CellPhone,
                        Email = titleCompanyAddViewModel.Email,
                        Address_Line1 = titleCompanyAddViewModel.AddressLine1,
                        Address_Line2 = titleCompanyAddViewModel.AddressLine2,
                        Address_City = titleCompanyAddViewModel.City,
                        Address_StateId = titleCompanyAddViewModel.StateId,
                        Address_ZipCode = titleCompanyAddViewModel.ZipCode,
                        CreatedBy = 1,
                        LastUpdatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                    };

                    await _titleCompanyRepository.AddTitleCompanyAsync(titleCompany);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the title company failed, please try again! Error: {ex.Message}");
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            titleCompanyAddViewModel.States = selectStates;
            
            return View(titleCompanyAddViewModel);
        }
    }
}
