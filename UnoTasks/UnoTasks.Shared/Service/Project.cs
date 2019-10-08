using UnoTasks.Service;

namespace Uno.Tasks.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectType ProjectType { get; set; }
        public ProjectStatus Status { get; set; }
    }
}