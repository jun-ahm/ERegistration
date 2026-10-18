using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface IPropertyOwnerRepository
    {
        Task<int> AddPropertyOwnerAsync(PropertyOwner propertyOwner);
        Task<IEnumerable<PropertyOwner>> GetAllPropertyOwnerAsync();
    }
}