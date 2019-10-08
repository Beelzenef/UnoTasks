namespace Uno.Tasks.Projects
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected bool Equals(ProjectType other)
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

            return Equals((ProjectType) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}