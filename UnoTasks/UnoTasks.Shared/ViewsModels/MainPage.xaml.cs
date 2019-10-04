using System.Collections.Generic;
using UnoTasks.Shared.Models;
using UnoTasks.Shared.Services;
using UnoTasks.Shared.ViewsModels;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static UnoTasks.Shared.Models.Item;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoTasks.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            this.ViewModel = new MainPageViewModel();
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
    }
}
