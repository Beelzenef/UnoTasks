using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnoTasks.Service;

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
                ProjectType = Types[x-1],
                Status = Statuses.First(),
            }));
        }

        public Task<IEnumerable<ProjectType>> GetProjectTypes()
        {
            return Task.FromResult((IEnumerable<ProjectType>)Types);
        }

        public Task<IEnumerable<ProjectStatus>> GetStatuses()
        {
            return Task.FromResult((IEnumerable<ProjectStatus>)Statuses);
        }

        private static List<ProjectStatus> Statuses
        {
            get
            {
                var statuses = new[] {"New", "Closed", "In Progress", "Abandoned", "Paused"};
                return statuses.Select((name, id) => new ProjectStatus() {Id = id, Name = name}).ToList();
            }
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