using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERegistration.Repositories
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public ContractorRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<IEnumerable<Contractor>> GetAllContractorsAsync()
        {
            return await _eRegistrationDbContext.Contractors.Include(c => c.BusinessType).OrderBy(c => c.BusinessName).ThenBy(c => c.FirstName).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddContractorAsync(Contractor contractor)
        {
            _eRegistrationDbContext.Contractors.Add(contractor);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }
    }
}