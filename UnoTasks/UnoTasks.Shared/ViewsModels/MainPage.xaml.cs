using System;
using UnoTasks.Shared.Models;
using UnoTasks.Shared.ViewsModels;
using Windows.UI;
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
            Color color = Colors.Red;
            switch (ViewModel.Item.CurrentStatus)
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
            ViewModel.StatusColor = color;
        }

        private void ItemType_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var color = Colors.Red;
            switch (ViewModel.Item.TaskType)
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
            ViewModel.TypeColor = color;
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddItemPage));
        }
    }
}
