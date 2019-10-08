using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uno.Tasks.Projects
{
    public interface IProjectProvider
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<IEnumerable<ProjectType>> GetProjectTypes();
    }
}