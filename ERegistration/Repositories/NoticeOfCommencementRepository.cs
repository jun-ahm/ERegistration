using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ERegistration.ViewModels;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Reflection;

namespace ERegistration.Repositories
{
    public class NoticeOfCommencementRepository : INoticeOfCommencementRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public NoticeOfCommencementRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<int> AddNoticeOfCommencementAsync(NoticeOfCommencement noc)
        {
            _eRegistrationDbContext.NoticeOfCommencements.Add(noc);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }

        public async Task<List<NoticeOfCommencementReport>> GetNocReportByIdAsync(int nocId)
        {
            return await _eRegistrationDbContext.Database.SqlQuery<NoticeOfCommencementReport>($"EXEC NoticeOfCommencementDetails @noticeOfCommencementId={nocId}").ToListAsync();
        }

        public async Task<NoticeOfCommencementDetailsViewModel?> GetNocByIdAsync(int nocId)
        {
            return await _eRegistrationDbContext.NoticeOfCommencements.AsNoTracking().Where(n => n.Id == nocId)
                .Select(n => new NoticeOfCommencementDetailsViewModel
                {
                    Id = n.Id,
                    Contractor = new ContractorDetailsViewModel
                    {
                        Id = n.Contractor.Id,
                        BusinessName = n.Contractor.BusinessName!,
                        FirstName = n.Contractor.FirstName,
                        MiddleName = n.Contractor.MiddleName,
                        LastName = n.Contractor.LastName,
                        LicenseNumber = n.Contractor.LicenseNumber,
                        Email = n.Contractor.Email,
                        OfficePhone = n.Contractor.OfficePhone,
                        CellPhone = n.Contractor.CellPhone,
                        Address_Line1 = n.Contractor.Address_Line1,
                        Address_Line2 = n.Contractor.Address_Line2,
                        Address_City = n.Contractor.Address_City,
                        Address_State = n.Contractor.Address_State.Name,
                        Address_StateId = n.Contractor.Address_State.Id,
                        Address_ZipCode = n.Contractor.Address_ZipCode
                    },
                    Project = new ProjectDetailsViewModel
                    {
                        Id = n.Project.Id,
                        LegalDescription = n.Project.AdditionalDescription,
                        Address_Line1 = n.Project.Address_Line1,
                        Address_Line2 = n.Project.Address_Line2,
                        Address_Line3 = n.Project.Address_Line3,
                        Address_City = n.Project.Address_City,
                        Address_State = n.Project.Address_State.Name,
                        Address_ZipCode = n.Project.Address_ZipCode,
                        TaxParcelId = n.Project.PinNumber,
                        County = n.Project.County,
                        StartDate = n.Project.StartDate.ToString(),
                        CompletionDate = n.Project.CompletionDate.ToString()
                    },
                    Lender = new LenderDetailsViewModel
                    {
                        Id = n.Lender.Id,
                        Name = n.Lender.BusinessName!,
                        FirstName = n.Lender.FirstName,
                        MiddleName = n.Lender.MiddleName,
                        LastName = n.Lender.LastName,
                        Email = n.Lender.Email,
                        Phone = n.Lender.Phone,
                        CellPhone = n.Lender.CellPhone,
                        Address_Line1 = n.Lender.Address_Line1,
                        Address_Line2 = n.Lender.Address_Line2,
                        Address_City = n.Lender.Address_City,
                        Address_State = n.Lender.Address_State.Name,
                        Address_ZipCode = n.Lender.Address_ZipCode
                    },
                    TitleCompany = new TitleCompanyDetailsViewModel
                    {
                        Id = n.TitleCompany.Id,
                        Name = n.TitleCompany.Name!,
                        Title = n.TitleCompany.Title,
                        FirstName = n.TitleCompany.FirstName,
                        MiddleName = n.TitleCompany.MiddleName,
                        LastName = n.TitleCompany.LastName,
                        Email = n.TitleCompany.Email,
                        Phone = n.TitleCompany.Phone,
                        CellPhone = n.TitleCompany.CellPhone,
                        Address_Line1 = n.TitleCompany.Address_Line1,
                        Address_Line2 = n.TitleCompany.Address_Line2,
                        Address_City = n.TitleCompany.Address_City,
                        Address_State = n.TitleCompany.Address_State.Name,
                        Address_ZipCode = n.TitleCompany.Address_ZipCode
                    },
                    PropertyOwners = n.PropertyOwners.Select (po => new PropertyOwnerDetailsViewModel
                    {
                        Id = po.PropertyOwner.Id,
                        FirstName = n.PropertyOwner.FirstName,
                        MiddleName = n.PropertyOwner.MiddleName,
                        LastName = n.PropertyOwner.LastName,
                        Email = n.PropertyOwner.Email,
                        Phone = n.PropertyOwner.Phone,
                        Address_Line1 = n.PropertyOwner.Address_Line1,
                        Address_Line2 = n.PropertyOwner.Address_Line2,
                        Address_City = n.PropertyOwner.Address_City,
                        Address_State = n.PropertyOwner.Address_State.Name,
                        Address_ZipCode = n.PropertyOwner.Address_ZipCode
                    }).ToList(),
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NoticeOfCommencement>> GetAllNocsAsync()
        {
            return await _eRegistrationDbContext.NoticeOfCommencements.Include(p => p.PropertyOwners)
                .Include(co => co.Contractor).Include(p => p.Project).Include(s => s.Project.Address_State).OrderBy(c => c.LastUpdatedDate).ToListAsync();
        }
    }
}