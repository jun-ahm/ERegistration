using ERegistration.Models;
using ERegistration.Models.Repositories;
using ERegistration.Models.Repositories.Interfaces;
using ERegistration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;

namespace ERegistration.Controllers
{
    //[Authorize]
    //[Authorize(Roles = "Admin, User")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly ILookupValueRepository _lookupValueRepository;

        public ProjectController(IProjectRepository projectRepository, ILookupValueRepository lookupValueRepository, ILogger<ProjectController> logger)
        {
            _projectRepository = projectRepository;
            _lookupValueRepository = lookupValueRepository;
            _logger = logger;
        }

        // GET: ProjectController
        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            return View(projects);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewData["Title"] = "Add Project";
                var states = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);

                var projectTypes = await _lookupValueRepository.GetLookupForDropdownAsync();
                IEnumerable<SelectListItem> selectProjectTypes = new SelectList(projectTypes.Where(p=>p.Entity== "ProjectTypes"), "Id", "Name", null);

                var projectSubTypes1 = await _lookupValueRepository.GetLookupForDropdownAsync();                
                IEnumerable<SelectListItem> selectProjectSubTypes1 = new SelectList(projectSubTypes1.Where(p => p.Entity == "ProjectSubTypes1"), "Id", "Name", null);

                var projectSubTypes2 = await _lookupValueRepository.GetLookupForDropdownAsync();                
                IEnumerable<SelectListItem> selectProjectSubTypes2 = new SelectList(projectTypes.Where(p => p.Entity == "ProjectSubTypes2"), "Id", "Name", null);

                ProjectAddViewModel projectAddViewModel = new() { States = selectStates, ProjectTypes = selectProjectTypes, ProjectSubTypes1 = selectProjectSubTypes1, ProjectSubTypes2 = selectProjectSubTypes2 };
                return View(projectAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new ProjectAddViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProjectAddViewModel projectAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Project project = new()
                    {
                        Name = projectAddViewModel.Project.Name,
                        Lot = projectAddViewModel.Project.Lot,
                        Block = projectAddViewModel.Project.Block,
                        AdditionalDescription = projectAddViewModel.Project.AdditionalDescription,
                        Address_Line1 = projectAddViewModel.Project.Address_Line1,
                        Address_Line2 = projectAddViewModel.Project.Address_Line2,
                        Address_City = projectAddViewModel.Project.Address_City,
                        Address_StateId = projectAddViewModel.Project.Address_StateId,
                        Address_ZipCode = projectAddViewModel.Project.Address_ZipCode,

                        //ProjectAddress = new Address
                        //{
                        //    Address_Line1 = projectAddViewModel.Project.ProjectAddress.Address_Line1,
                        //    Address_Line2 = projectAddViewModel.Project.ProjectAddress.Address_Line2,
                        //    Address_City = projectAddViewModel.Project.ProjectAddress.Address_City,
                        //    Address_StateId = projectAddViewModel.Project.ProjectAddress.Address_StateId,
                        //    Address_ZipCode = projectAddViewModel.Project.ProjectAddress.Address_ZipCode,
                        //},                        
                        //Address1 = projectAddViewModel.Project.ProjectAddress.Address_Line1,
                        //Address2 = projectAddViewModel.Project.ProjectAddress.Address_Line2,
                        //City = projectAddViewModel.Project.ProjectAddress.Address_City,
                        //StateId = projectAddViewModel.Project.ProjectAddress.Address_StateId,
                        //ZipCode = projectAddViewModel.Project.ProjectAddress.Address_ZipCode,
                        
                        County = projectAddViewModel.Project.County,
                        PinNumber = projectAddViewModel.Project.PinNumber,
                        ProjectTypeId = projectAddViewModel.Project.ProjectTypeId,
                        ProjectSubType1Id = projectAddViewModel.Project.ProjectSubType1Id,
                        ProjectSubType2Id = projectAddViewModel.Project.ProjectSubType2Id,
                        StartDate = projectAddViewModel.Project.StartDate,
                        CompletionDate = projectAddViewModel.Project.CompletionDate,
                        IsApproved = true,
                        Deleted = false,
                        CreatedBy = 1,
                        LastUpdatedBy = 1,
                        CreationDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                    };

                    await _projectRepository.AddProjectAsync(project);
                    return RedirectToAction("Index", "NoticeOfCommencement");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the project failed, please try again! Error: {ex.Message}");
            }

            var states = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectStates = new SelectList(states.Where(p => p.Entity == "States"), "Id", "Name", null);
            projectAddViewModel.States = selectStates;

            var projectTypes = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectProjectTypes = new SelectList(projectTypes.Where(p => p.Entity == "ProjectTypes"), "Id", "Name", null);
            projectAddViewModel.ProjectTypes = selectProjectTypes;

            var projectSubTypes1 = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectProjectSubTypes1 = new SelectList(projectSubTypes1.Where(p => p.Entity == "ProjectSubTypes1"), "Id", "Name", null);
            projectAddViewModel.ProjectSubTypes1 = selectProjectSubTypes1;

            var projectSubTypes2 = await _lookupValueRepository.GetLookupForDropdownAsync();
            IEnumerable<SelectListItem> selectProjectSubTypes2 = new SelectList(projectSubTypes2.Where(p => p.Entity == "ProjectSubTypes2"), "Id", "Name", null);
            projectAddViewModel.ProjectSubTypes2 = selectProjectSubTypes2;

            return View(projectAddViewModel);
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
