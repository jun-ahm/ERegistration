using ERegistration.Models;

namespace ERegistration.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<int> AddProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}