using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERegistration.Repositories
{
    public class PropertyOwnerRepository : IPropertyOwnerRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public PropertyOwnerRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<IEnumerable<PropertyOwner>> GetAllPropertyOwnersAsync()
        {
            return await _eRegistrationDbContext.PropertyOwners.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddPropertyOwnerAsync(PropertyOwner propertyOwner)
        {
            _eRegistrationDbContext.PropertyOwners.Add(propertyOwner);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }
    }
}