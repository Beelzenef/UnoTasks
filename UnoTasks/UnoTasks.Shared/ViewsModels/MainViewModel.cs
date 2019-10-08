using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Uno.Tasks.Projects;
using UnoTasks.ViewsModels;

namespace ViewsModels
{
    public class MainViewModel : ReactiveObject
    {
        private List<ProjectViewModel> projects;

        public MainViewModel(IProjectProvider projectProvider)
        {
            LoadProjects = ReactiveCommand.CreateFromTask(() => HereLoadProjects(projectProvider));
            LoadProjects.Subscribe(tuple => Projects = tuple.projs.Select(p => new ProjectViewModel(p, tuple.types)).ToList());
        }

        private async Task<(IEnumerable<Project> projs, IEnumerable<ProjectType> types)> HereLoadProjects(IProjectProvider projectProvider)
        {
            var projs = await projectProvider.GetProjects();
            var types = await projectProvider.GetProjectTypes();

            return (projs, types);
        }

        public ReactiveCommand<Unit, (IEnumerable<Project> projs, IEnumerable<ProjectType> types)> LoadProjects { get; set; }

        public List<ProjectViewModel> Projects
        {
            get => projects;
            set => this.RaiseAndSetIfChanged(ref projects, value);
        }
    }
}