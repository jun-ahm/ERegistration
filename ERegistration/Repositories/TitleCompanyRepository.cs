using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERegistration.Repositories
{
    public class TitleCompanyRepository : ITitleCompanyRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public TitleCompanyRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<IEnumerable<TitleCompany>> GetAllTitleCompaniesAsync()
        {
            return await _eRegistrationDbContext.TitleCompanies.OrderBy(l => l.Name).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddTitleCompanyAsync(TitleCompany titleCompany)
        {
            _eRegistrationDbContext.TitleCompanies.Add(titleCompany);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }
    }
}