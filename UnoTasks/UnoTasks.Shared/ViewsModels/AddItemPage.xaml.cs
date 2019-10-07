using UnoTasks.Shared.Models;
using UnoTasks.ViewsModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoTasks.Shared.ViewsModels
{
    public sealed partial class AddItemPage : Page
    {
        public AddItemViewModel ViewModel { get; private set; }

        public AddItemPage()
        {
            this.InitializeComponent();
            ViewModel = new AddItemViewModel();
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var itemToAdd = new NewItem
            {
                Id = ViewModel.NewItem.Id,
                Description = ViewModel.NewItem.Description
            };

            Frame.Navigate(typeof(MainPage), itemToAdd);
        }
    }
}
