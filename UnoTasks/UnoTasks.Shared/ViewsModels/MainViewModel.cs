using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Uno.Tasks.Projects;
using UnoTasks.Service;
using UnoTasks.ViewsModels;

namespace ViewsModels
{
    public class MainViewModel : ReactiveObject
    {
        private ObservableCollection<ProjectViewModel> projects;
        private IEnumerable<ProjectStatus> statuses;
        private IEnumerable<ProjectType> projectTypes;

        public MainViewModel(IProjectProvider projectProvider)
        {
            LoadProjects = ReactiveCommand.CreateFromTask(() => LoadProjectsAndTypes(projectProvider));
            LoadProjects.Subscribe(tuple =>
            {
                Projects = new ObservableCollection<ProjectViewModel>(tuple.projs.Select(p =>
                        new ProjectViewModel(p, tuple.types, tuple.statuses)));
                ProjectTypes = tuple.types;
                Statuses = tuple.statuses;
            });

            AddNew = ReactiveCommand.Create(() =>
                    Projects.Add(new ProjectViewModel(new Project() { Id = Projects.Count + 1 }, ProjectTypes, Statuses)),
                this.WhenAnyValue(x => x.ProjectTypes, x => x.Statuses, (pt, st) => pt != null && st != null));
        }

        public ReactiveCommand<Unit, Unit> AddNew { get; set; }

        public IEnumerable<ProjectStatus> Statuses
        {
            get => statuses;
            set => this.RaiseAndSetIfChanged(ref statuses, value);
        }

        public IEnumerable<ProjectType> ProjectTypes
        {
            get => projectTypes;
            set => this.RaiseAndSetIfChanged(ref projectTypes, value);
        }

        private static async Task<(IEnumerable<Project> projs, IEnumerable<ProjectType> types, IEnumerable<ProjectStatus> statuses)> LoadProjectsAndTypes(IProjectProvider projectProvider)
        {
            var projs = await projectProvider.GetProjects();
            var types = await projectProvider.GetProjectTypes();
            var statuses = await projectProvider.GetStatuses();

            return (projs, types, statuses);
        }

        public ReactiveCommand<Unit, (IEnumerable<Project> projs, IEnumerable<ProjectType> types, IEnumerable<ProjectStatus> statuses)> LoadProjects { get; set; }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get => projects;
            set => this.RaiseAndSetIfChanged(ref projects, value);
        }


    }
}