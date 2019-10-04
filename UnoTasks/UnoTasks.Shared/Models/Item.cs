using MvvmHelpers;
using Windows.UI;

namespace UnoTasks.Shared.Models
{
    public class Item : ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _title;
        public string Title 
        {
            get {  return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _description;
        public string Description {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private ItemStatus _currentStatus;
        public ItemStatus CurrentStatus {
            get { return _currentStatus; }
            set { SetProperty(ref _currentStatus, value); }
        }

        private ItemType _taskType;
        public ItemType TaskType {
            get { return _taskType; } 
            set { SetProperty(ref _taskType, value); }
        }

        private Color _statusColor;
        public Color StatusColor
        {
            get => _statusColor;
            set => _statusColor = value;
        }

        private Color _typeColor;
        public Color TypeColor
        {
            get => _typeColor;
            set => _typeColor = value;
        }

        public ItemStatus[] StatusList => new[]
        {
            ItemStatus.New,
            ItemStatus.Closed,
            ItemStatus.InPause,
            ItemStatus.InProgress,
            ItemStatus.Abandoned
        };

        public ItemType[] TypeList => new[]
        {
            ItemType.Documentation,
            ItemType.GameDesign,
            ItemType.Programming,
            ItemType.Testing,
            ItemType.UserInterface
        };

        public enum ItemStatus
        {
            New,
            Closed,
            InProgress,
            Abandoned,
            InPause
        }

        public enum ItemType
        {
            Programming,
            GameDesign,
            UserInterface,
            Documentation,
            Testing
        }
    }
}
