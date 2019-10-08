using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Uno.Tasks.Projects;
using ViewsModels;

namespace UnoTasks.ViewsModels
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new MainViewModel(new ProjectProvider());
        }
    }
}
