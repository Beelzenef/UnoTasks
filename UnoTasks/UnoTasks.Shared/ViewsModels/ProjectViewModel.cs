using System.Collections.Generic;
using ReactiveUI;
using Uno.Tasks.Projects;
using UnoTasks.Service;

namespace UnoTasks.ViewsModels
{
    public class ProjectViewModel : ReactiveObject
    {
        private ProjectType projectType;
        private ProjectStatus status;

        public ProjectViewModel(Project innerProject, IEnumerable<ProjectType> projectTypes,
            IEnumerable<ProjectStatus> statuses)
        {
            Name = innerProject.Name;
            Description = innerProject.Description;
            Id = innerProject.Id;
            ProjectType = innerProject.ProjectType;
            Status = innerProject.Status;

            ProjectTypes = projectTypes;
            Statuses = statuses;
        }

        public IEnumerable<ProjectType> ProjectTypes { get; }

        public IEnumerable<ProjectStatus> Statuses { get; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ProjectType ProjectType
        {
            get => projectType;
            set => this.RaiseAndSetIfChanged(ref projectType, value);
        }

        public ProjectStatus Status
        {
            get => status;
            set => this.RaiseAndSetIfChanged(ref status, value);
        }
    }
}