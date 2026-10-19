using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERegistration.Repositories
{
    public class LenderRepository : ILenderRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public LenderRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<IEnumerable<Lender>> GetAllLendersAsync()
        {
            return await _eRegistrationDbContext.Lenders.OrderBy(l => l.BusinessName).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddLenderAsync(Lender lender)
        {
            _eRegistrationDbContext.Lenders.Add(lender);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }
    }
}