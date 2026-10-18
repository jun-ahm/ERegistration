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
        private readonly ILenderRepository _lenderRepository;
        private readonly ITitleCompanyRepository _titleCompanyRepository;
        private readonly INoticeOfCommencementRepository _noticeOfCommencementRepository;
        private readonly ILookupValueRepository _lookupValueRepository
        private readonly ERegistrationDbContext _eRegistrationDbContext;


        public NoticeOfCommencementController(ERegistrationDbContext eRegistrationDbContext, ILookupValueRepository lookupValueRepository, IContractorRepository contractorRepository, IProjectRepository projectRepository, IPropertyOwnerRepository propertyOwnerRepository, 
        ILenderRepository lenderRepository, ITitleCompanyRepository titleCompanyRepository, INoticeOfCommencementRepository noticeOfCommencementRepository, ILogger<NoticeOfCommencementController> logger)
        {
            _projectRepository = projectRepository;
            _contractorRepository = contractorRepository;
            _propertyOwnerRepository = propertyOwnerRepository;
            _lenderRepository = lenderRepository;
            _titleCompanyRepository = titleCompanyRepository;
            _noticeOfCommencementRepository = noticeOfCommencementRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoticeOfCommencementViewModel nocEditViewModel)
        {
            using var transaction = await _eRegistrationDbContext.Database.BeginTransactionAsync();
            try
            {
                var contractor = await _eRegistrationDbContext.Contractors.FindAsync(nocEditViewModel.Contractor.Id);

                if(contractor != null)
                {
                    contractor.FirstName = nocEditViewModel.Contractor.FirstName;
                    contractor.MiddleName = nocEditViewModel.Contractor.MiddleName;
                    contractor.LastName = nocEditViewModel.Contractor.LastName;
                    contractor.BusinessName = nocEditViewModel.Contractor.BusinessName;
                    contractor.LicenseNumber = nocEditViewModel.Contractor.LicenseNumber;
                    contractor.Address_Line1 = nocEditViewModel.Contractor.Address_Line1;
                    contractor.Address_Line2 = nocEditViewModel.Contractor.Address_Line2;
                    contractor.Address_City = nocEditViewModel.Contractor.Address_City;
                    contractor.Address_StateId = nocEditViewModel.Contractor.Address_StateId;
                    contractor.Address_ZipCode = nocEditViewModel.Contractor.Address_ZipCode;   
                }
                
                var project = await _eRegistrationDbContext.Projects.FindAsync(nocEditViewModel.Project.Id);
                if(project != null)
                {
                    project.ProjectName = nocEditViewModel.Project.ProjectName;
                    project.Address_Line1 = nocEditViewModel.Project.Address_Line1;
                    project.Address_Line2 = nocEditViewModel.Project.Address_Line2;
                    project.Address_Line3 = nocEditViewModel.Project.Address_Line3;
                    project.Address_City = nocEditViewModel.Project.Address_City;
                    project.Address_StateId = nocEditViewModel.Project.Address_StateId;
                    project.Address_ZipCode = nocEditViewModel.Project.Address_ZipCode;
                    project.County = nocEditViewModel.Project.County;
                    project.PinNumber = nocEditViewModel.Project.TaxParcel;
                    project.AdditionalDescription = nocEditViewModel.Project.LegalDescription;
                    project.StartDate = nocEditViewModel.Project.StartDate;
                    project.EndDate = nocEditViewModel.Project.EstimatedCompletionDate;
                }

                foreach (var propertyOwner in nocEditViewModel.PropertyOwners)
                {
                    var existingPropertyOwner = await _eRegistrationDbContext.PropertyOwners.FindAsync(propertyOwner.Id);
                    if (existingPropertyOwner != null)
                    {
                        existingPropertyOwner.FirstName = propertyOwner.FirstName;
                        existingPropertyOwner.MiddleName = propertyOwner.MiddleName;
                        existingPropertyOwner.LastName = propertyOwner.LastName;
                        existingPropertyOwner.Address_Line1 = propertyOwner.Address_Line1;
                        existingPropertyOwner.Address_Line2 = propertyOwner.Address_Line2;
                        existingPropertyOwner.Address_City = propertyOwner.Address_City;
                        existingPropertyOwner.Address_StateId = propertyOwner.Address_StateId;
                        existingPropertyOwner.Address_ZipCode = propertyOwner.Address_ZipCode;
                        existingPropertyOwner.Email = propertyOwner.Email;
                        existingPropertyOwner.Phone = propertyOwner.Phone;
                    }
                }
                
                await _eregistrationDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return RedirectToAction("Details", new { id = nocEditViewModel.Id });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var noc = await _noticeOfCommencementRepository.GetNoticeOfCommencementByIdAsync(id);
            if (noc == null)
            {
                return NotFound();
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            
            var viewModel = new NoticeOfCommencementViewModel
            {
                Id = noc.Id,
                Contractor = new ContractorEditViewModel
                {
                    Id = noc.Contractor.Id,
                    BusinessName = noc.Contractor.BusinessName,
                    FirstName = noc.Contractor.FirstName,
                    MiddleName = noc.Contractor.MiddleName,
                    LastName = noc.Contractor.LastName,
                    Address_Line1 = noc.Contractor.Address_Line1,
                    Address_Line2 = noc.Contractor.Address_Line2,
                    Address_City = noc.Contractor.Address_City,
                    Address_StateId = noc.Contractor.Address_StateId,
                    Address_State = noc.Contractor.Address_State,
                    Address_ZipCode = noc.Contractor.Address_ZipCode,
                    LicenseNumber = noc.Contractor.LicenseNumber,
                    Email = noc.Contractor.Email,
                    OfficePhone = noc.Contractor.OfficePhone,
                },
                Project = new ProjectEditViewModel
                {
                    Id = noc.Project.Id,
                    Address_Line1 = noc.Project.Address_Line1,
                    Address_Line2 = noc.Project.Address_Line2,
                    Address_Line3 = noc.Project.Address_Line3,
                    Address_City = noc.Project.Address_City,
                    Address_StateId = noc.Project.Address_StateId,
                    Address_State = noc.Project.Address_State,
                    Address_ZipCode = noc.Project.Address_ZipCode,
                    County = noc.Project.County,
                    TaxParcel = noc.Project.TaxParcelId,
                    LegalDescription = noc.Project.LegalDescription,
                    StartDate = DateTime.TryParse(noc.Project.StartDate, out DateTime startDate) ? startDate : DateTime.MinValue,
                    EstimatedCompletionDate = DateTime.TryParse(noc.Project.EstimatedCompletionDate, out DateTime estimatedCompletionDate) ? estimatedCompletionDate : DateTime.MinValue
                },
                Lender = new LenderEditViewModel
                {
                    Id = noc.Lender.Id,
                    BusinessName = noc.Lender.Name,
                    FirstName = noc.Lender.FirstName,
                    MiddleName = noc.Lender.MiddleName,
                    LastName = noc.Lender.LastName,
                    Address_Line1 = noc.Lender.Address_Line1,
                    Address_Line2 = noc.Lender.Address_Line2,
                    Address_City = noc.Lender.Address_City,
                    Address_StateId = noc.Lender.Address_StateId,
                    Address_State = selectedStates,
                    Address_ZipCode = noc.Lender.Address_ZipCode,
                    Email = noc.Lender.Email,
                    OfficePhone = noc.Lender.Phone,
                    CellPhone = noc.Lender.CellPhone
                },
                PropertyOwners = noc.PropertyOwners.Select(po => new PropertyOwnerEditViewModel
                {
                    PropertyOwnerId = po.Id,
                    FirstName = po.FirstName,
                    MiddleName = po.MiddleName,
                    LastName = po.LastName,
                    Address_Line1 = po.Address_Line1,
                    Address_Line2 = po.Address_Line2,
                    Address_City = po.Address_City,
                    Address_StateId = po.Address_StateId,
                    Address_State = selectedStates,
                    Address_ZipCode = po.Address_ZipCode,
                    Email = po.Email
                }).ToList()
            };

            return View(viewModel);
        }

        public async Task<IactionResult> Download(int id)
        {
            var noc = await _noticeOfCommencementRepository.GetNocReportByIdAsync(id);
            if (noc == null)
            {
                return NotFound();
            }

            var rdlcFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "NoticeOfCommencement.rdlc");
            if(!System.IO.File.Exists(rdlcFilePath))
            {
                return Content($"Report file not found: {rdlcFilePath}");
            }

            LocalReport report = new LocalReport(rdlcFilePath);
            using(var fs = System.IO.File.OpenRead(rdlcFilePath))
            {
                report.LoadReportDefinition(fs);
            }

            ReportDataSource dataSource = new ReportDataSource("NoticeOfCommencementDataSet", noc.Result);
            report.DataSources.Clear();
            report.DataSources.Add(dataSource);

            byte[] pdfBytes = report.Render("PDF");

            var ContentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = $"NoticeOfCommencement_{DateTime.Now:yyyyMMddHHmmss}.pdf",
                Inline = true
            };

            Response.Headers.Add("Content-Disposition", ContentDisposition.ToString());
            return File(pdfBytes, "application/pdf");
        }

        [HttpPost]
        //public async Task<IActionResult> Create(NoticeOfCommencementViewModel nocAddViewModel)
        public Task<IActionResult> Create(NoticeOfCommencementViewModel nocAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<NoticeOfCommencementPropertyOwner> nocPropertyOwners = new List<NoticeOfCommencementPropertyOwner>();
                    for(int i = 0; i < nocAddViewModel.SelectPropertyOwnerId.Count; i++)
                    {
                        NoticeOfCommencementPropertyOwner nocPropertyOwner = new NoticeOfCommencementPropertyOwner
                        {
                            PropertyOwnerId = nocAddViewModel.SelectPropertyOwnerId[i],
                            CreatedBy = 1,
                            CreationDate = DateTime.Now,
                            LastUpdatedBy = 1,
                            LastUpdatedDate = DateTime.Now
                        };
                        nocPropertyOwners.Add(nocPropertyOwner);
                    }

                    NoticeOfCommencement noc = new NoticeOfCommencement
                    {
                        ContractorId = nocAddViewModel.SelectedContractorId,
                        LenderId = nocAddViewModel.SelectedLenderId,
                        TitleCompanyId = nocAddViewModel.SelectedTitleCompanyId,
                        ProjectId = nocAddViewModel.SelectedProjectId,
                        PropertyOwners = nocPropertyOwners,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedBy = 1,
                        LastUpdatedDate = DateTime.Now
                    };
                    await _noticeOfCommencementRepository.AddNoticeOfCommencementAsync(noc);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the contractor failed, please try again! Error: {ex.Message}");
            }

            return RedirectToAction("Index", "NoticeOfCommencement");
        }

        public IActionResult AddPropertyOwner()
        {
            return ViewComponent("SelectPropertyOwner");
        }

        public async Task<IACtionResult> Add()
        {
            var viewModel = new NoticeOfCommencementViewModel();

            var contractors = await _contractorRepository.GetAllContractorsAsync();
            viewModel.Contractors = new SelectList(contractors, "Id", "FullName");

            var projects = await _projectRepository.GetAllProjectsAsync();
            viewModel.Projects = new SelectList(projects, "Id", "Name");

            var lenders = await _lenderRepository.GetAllLendersAsync();
            viewModel.Lenders = new SelectList(lenders, "Id", "BusinessName");

            var titleCompanies = await _titleCompanyRepository.GetAllTitleCompaniesAsync();
            viewModel.TitleCompanies = new SelectList(titleCompanies, "Id", "Name");

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var noc = await _noticeOfCommencementRepository.GetNocByIdAsync(id);
            if (noc == null)
            {
                return NotFound();
            }

            return View(noc);
        }

        public async Task<IActionResult> Index()
        {
            var nocs = await _noticeOfCommencementRepository.GetAllNocsAsync();
            return View(noc);                    
        }
    }
}
