using System.Collections.Generic;
using System.Threading.Tasks;
using UnoTasks.Service;

namespace Uno.Tasks.Projects
{
    public interface IProjectProvider
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<IEnumerable<ProjectType>> GetProjectTypes();
        Task<IEnumerable<ProjectStatus>> GetStatuses();
    }
}