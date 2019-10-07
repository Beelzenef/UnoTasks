using UnoTasks.Shared.Models;

namespace UnoTasks.Shared.ViewsModels
{
    public class AddItemViewModel
    {
        private NewItem _newItem = new NewItem();
        public NewItem NewItem
        {
            get => _newItem;
            set => _newItem = value;
        }
    }
}
