using System;
using UnoTasks.Shared.Models;
using UnoTasks.Shared.ViewsModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using static UnoTasks.Shared.Models.Item;

namespace UnoTasks.ViewsModels
{
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            this.ViewModel = new MainPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var itemToAdd = e.Parameter as NewItem;

            if (itemToAdd != null)
            {
                var newItem = MapToItem(itemToAdd);

                ViewModel.Items.Add(newItem);
            }
        }

        private Item MapToItem(NewItem itemToAdd)
        {
            return new Item
            {
                Id = ToNumber(itemToAdd.Id),
                Description = itemToAdd.Description,
                TaskType = ItemType.Programming,
                CurrentStatus = ItemStatus.New
            };
        }

        private int ToNumber(string number)
        {
            int result = 0;

            try
            {
                result = int.Parse(number);
            }
            catch (Exception e)
            {
                return result;
            }

            return result;
        }


        private void StatusPicker_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ViewModel.ChangeStatus();
        }

        private void ItemType_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ViewModel.ChangeType();
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Go(new AddItemPage());
        }
    }
}
