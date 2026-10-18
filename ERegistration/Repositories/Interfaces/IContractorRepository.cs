using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface IContractorRepository
    {
        Task<int> AddContractorAsync(Contractor contractor);
        Task<IEnumerable<Contractor>> GetAllContractorsAsync();
    }
}