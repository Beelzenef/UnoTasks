using System.Collections.ObjectModel;
using UnoTasks.Shared.Models;
using UnoTasks.Shared.Services;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using static UnoTasks.Shared.Models.Item;

namespace UnoTasks.Shared.ViewsModels
{
    public class MainPageViewModel
    {
        private Item _item = new Item();
        public Item Item
        { 
            get => _item;
            set => _item = value;
        }

        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get => _items;
        }     

        private readonly ItemService _itemService;

        public MainPageViewModel()
        {
            _itemService = new ItemService();
            var items = _itemService.GetItems();

            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public void Go<T>(T type)
        {
            (Windows.UI.Xaml.Window.Current.Content as Frame)?.Navigate(type.GetType());
        }

        public void ChangeType()
        {
            var color = Colors.Red;
            switch (Item.TaskType)
            {
                case ItemType.Programming:
                    color = Colors.Green;
                    break;
                case ItemType.GameDesign:
                    color = Colors.Blue;
                    break;
                case ItemType.Testing:
                    color = Colors.Red;
                    break;
                case ItemType.Documentation:
                    color = Colors.Gray;
                    break;
                case ItemType.UserInterface:
                    color = Colors.Yellow;
                    break;
            }
            Item.TypeColor = new Windows.UI.Xaml.Media.SolidColorBrush(color);
        }

        internal void ChangeStatus()
        {
            Color color = Colors.Red;
            switch (Item.CurrentStatus)
            {
                case ItemStatus.Abandoned:
                    color = Colors.Red;
                    break;
                case ItemStatus.Closed:
                    color = Colors.Green;
                    break;
                case ItemStatus.InPause:
                    color = Colors.BlueViolet;
                    break;
                case ItemStatus.InProgress:
                    color = Colors.Yellow;
                    break;
                case ItemStatus.New:
                    color = Colors.Blue;
                    break;
            }
            Item.StatusColor = new Windows.UI.Xaml.Media.SolidColorBrush(color);
        }
    }
}
