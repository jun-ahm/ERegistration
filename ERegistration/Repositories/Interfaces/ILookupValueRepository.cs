using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface ILookupValueRepository
    {
        Task<List<LookupValue>> GetLookupForDropdownAsync();
    }
}