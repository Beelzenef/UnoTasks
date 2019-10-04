using System.Collections.Generic;
using UnoTasks.Shared.Data;
using UnoTasks.Shared.Models;

namespace UnoTasks.Shared.Services
{
    public class ItemService
    {
        public List<Item> GetItems()
        {
            return ItemMockData.ItemData();
        }
    }
}
