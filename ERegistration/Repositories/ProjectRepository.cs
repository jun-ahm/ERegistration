using ERegistration.Models;
using ERegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERegistration.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ERegistrationDbContext _eRegistrationDbContext;

        public ProjectRepository(ERegistrationDbContext eRegistrationDbContext)
        {
            _eRegistrationDbContext = eRegistrationDbContext;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _eRegistrationDbContext.Projects.OrderBy(p => p.Address_Line1).ThenBy(p => p.Address_Line2).AsNoTracking().ToListAsync();
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            _eRegistrationDbContext.Projects.Add(project);
            return await _eRegistrationDbContext.SaveChangesAsync();
        }
    }
}