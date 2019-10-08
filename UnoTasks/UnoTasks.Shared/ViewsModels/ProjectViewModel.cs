using System.Collections.Generic;
using ReactiveUI;
using Uno.Tasks.Projects;

namespace UnoTasks.ViewsModels
{
    public class ProjectViewModel : ReactiveObject
    {
        private ProjectType projectType;
        public IEnumerable<ProjectType> ProjectTypes { get; }

        public ProjectViewModel(Project innerProject, IEnumerable<ProjectType> projectTypes)
        {
            ProjectTypes = projectTypes;
            Name = innerProject.Name;
            Description = innerProject.Description;
            Id = innerProject.Id;
            ProjectType = innerProject.ProjectType;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ProjectType ProjectType
        {
            get => projectType;
            set => this.RaiseAndSetIfChanged(ref projectType, value);
        }
    }
}