using System;
using System.Collections.Generic;
using System.Text;
using UnoTasks.Shared.Models;
using static UnoTasks.Shared.Models.Item;

namespace UnoTasks.Shared.Data
{
    public class ItemMockData
    {
        public static List<Item> ItemData()
        {
            var itemList = new List<Item>
            {
                new Item
                {
                    CurrentStatus = Item.ItemStatus.Abandoned,
                    Title = "Stop starting new projects",
                    Description = "... and focus on the ones you already started, finish them!",
                    Id = 1,
                    TaskType = ItemType.GameDesign
                },
                new Item
                {
                    CurrentStatus = Item.ItemStatus.InProgress,
                    Title = "Choose genre",
                    Description = "FPS? RPG?",
                    Id = 2,
                    TaskType = ItemType.Programming
                },
                new Item
                {
                    Id = 101,
                    Title = "Getting started",
                    Description = "Define the game concept!",
                    CurrentStatus = ItemStatus.InProgress,
                    TaskType = ItemType.GameDesign
                }
            };

            return itemList;
        }
    }
}
