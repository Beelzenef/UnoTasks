using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uno.Tasks.Projects
{
    public class ProjectProvider : IProjectProvider
    {
        public Task<IEnumerable<Project>> GetProjects()
        {
            return Task.FromResult(Enumerable.Range(1, 6).Select(x => new Project()
            {
                Id = x,
                Name = $"Project {x}",
                Description = "This is a nice project",
                ProjectType = Types[x-1]
            }));
        }

        public Task<IEnumerable<ProjectType>> GetProjectTypes()
        {
            return Task.FromResult((IEnumerable<ProjectType>)Types);
        }

        private static List<ProjectType> Types
        {
            get
            {
                return Enumerable.Range(1, 6).Select(x => new ProjectType()
                {
                    Id = x,
                    Name = $"Type {x}",
                    Description = "This is a nice project",
                }).ToList();
            }
        }
    }
}