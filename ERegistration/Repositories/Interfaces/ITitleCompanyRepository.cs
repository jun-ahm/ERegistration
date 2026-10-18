using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface ITitleCompanyRepository
    {
        Task<int> AddTitleCompanyAsync(TitleCompany titleCompany);
        Task<IEnumerable<TitleCompany>> GetAllTitleCompaniesAsync();
    }
}