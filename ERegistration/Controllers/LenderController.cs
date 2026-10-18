using ERegistration.Models;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERegistration.Controllers
{
    public class LenderController : Controller
    {
        private readonly ILogger<LenderController> _logger;
        private readonly ILenderRepository _lenderRepository;
        private readonly ILookupValueRepository _lookupValueRepository;

        public LenderController(ILenderRepository lenderRepository, ILookupValueRepository lookupValueRepository, ILogger<LenderController> logger)
        {
            _lenderRepository = lenderRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var lenders = await _lenderRepository.GetAllLendersAsync();
            return View(lenders);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewData["Title"] = "Add Lender";

                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                LenderAddViewModel lenderAddViewModel = new() { States = selectStates };
                return View(lenderAddViewModel);                
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new LenderAddViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Add(LenderAddViewModel lenderAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    Lender lender = new()
                    {
                        BusinessName = lenderAddViewModel.Lender.BusinessName,
                        FirstName = lenderAddViewModel.Lender.FirstName,
                        MiddleName = lenderAddViewModel.Lender.MiddleName,
                        LastName = lenderAddViewModel.Lender.LastName,
                        Phone = lenderAddViewModel.Lender.Phone,
                        CellPhone = lenderAddViewModel.Lender.CellPhone,
                        Email = lenderAddViewModel.Lender.Email,
                        Address_Line1 = lenderAddViewModel.Lender.Address_Line1,
                        Address_Line2 = lenderAddViewModel.Lender.Address_Line2,
                        Address_City = lenderAddViewModel.Lender.Address_City,
                        Address_StateId = lenderAddViewModel.Lender.Address_StateId,
                        Address_ZipCode = lenderAddViewModel.Lender.Address_ZipCode,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedBy = 1,
                        LastUpdatedDate = DateTime.Now
                    };

                    await _lenderRepository.AddLenderAsync(lender);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }            
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the lender failed, please try again! Error: {ex.Message}");
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            lenderAddViewModel.States = selectStates;

            return View(lenderAddViewModel);
        }
    }
}
