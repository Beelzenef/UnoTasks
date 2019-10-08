namespace UnoTasks.Service
{
    public class ProjectStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected bool Equals(ProjectStatus other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((ProjectStatus) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}