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
            if (itemName is null) throw new ArgumentNullException(nameof(ItemName));

            ItemName = itemName;
        }

        public override string ToString()
        {
            return $"{ItemName}";
        }


    }
}