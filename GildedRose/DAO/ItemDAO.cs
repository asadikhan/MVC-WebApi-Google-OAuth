using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GildedRose.Models;

namespace GildedRose.DAO
{
    public static class ItemDAO
    {
        private static List<Item> items = new List<Item>
            {
            new Item { id = 1001, name="Rare China Doll", description="This is a rare miniature china doll.", price = 100, available = true },
            new Item { id = 1002, name="Hemingway's Lost Manuscripts", description="You won't believe the story behind how we traced down this rare historical literary gem.", price = 1000000, available = true },
            new Item { id = 1003, name="Signed Led Zeppelin Biography", description="Rare book signed by all four original rockers.", price = 450000, available = true},
            new Item { id = 1003, name="Peace and love", description="What else does one need? Indeed.", price = int.MaxValue, available = true}
            };

        public static Item[] GetItems()
        {
            return items.ToArray();
        }

        public static Item BuyItem(int id, string userName)
        {
            Item item = items.Find(x => x.id == id);
            if (item != null && item.available)
            {
                item.available = false;
                if (!String.IsNullOrEmpty(userName))
                {
                    item.soldToName = userName;
                }
            }

            return item;
        }

        public static void AddItem(Item item)
        {
            items.Add(
                new Item {
                    id = item.id,
                    name = item.name,
                    description = item.description,
                    price = item.price,
                    available = item.available,
                    soldToName = item.soldToName}
                );
        }
    }
}