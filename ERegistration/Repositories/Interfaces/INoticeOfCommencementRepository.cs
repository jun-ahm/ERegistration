using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface INoticeOfCommencementRepository
    {
        Task<int> AddNoticeOfCommencementAsync(NoticeOfCommencement noc);
        Task<IEnumerable<NoticeOfCommencement>> GetAllNocsAsync();

        Task<NoticeOfCommencementDetailsViewModel?> GetNocByIdAsync(int nocId);
        Task<List<NoticeOfCommencementReport>> GetNocReportByIdAsync(int nocId);
    }
}