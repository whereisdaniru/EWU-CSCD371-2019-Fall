using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class Item
    {
        public string ItemName { get; set; }

        public Item(string itemName)
        {
            ItemName = itemName ?? throw new ArgumentNullException(nameof(ItemName));
        }

        public override string ToString()
        {
            return $"{ItemName}";
        }


    }
}