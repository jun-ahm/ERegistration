using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface ILenderRepository
    {
        Task<int> AddLenderAsync(Lender lender);
        Task<IEnumerable<Lender>> GetAllLendersAsync();
    }
}