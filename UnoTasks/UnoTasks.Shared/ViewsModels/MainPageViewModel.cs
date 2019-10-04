using System.Collections.ObjectModel;
using UnoTasks.Shared.Models;
using UnoTasks.Shared.Services;
using Windows.UI;

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
    }
}
