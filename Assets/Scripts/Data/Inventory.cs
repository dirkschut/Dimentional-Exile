using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    /// <summary>
    /// This is the inventory system. It does what it says on the tin.
    /// </summary>
    public class Inventory
    {

        /// <summary>
        /// Creates an inventory with the given amount af slots.
        /// </summary>
        /// <param name="numslots">The amount of slots the inventory should have.</param>
        public Inventory(int numslots)
        {
            Items = new Item[numslots];
        }

        private static Inventory globalInventory;
        public static Inventory GlobalInventory
        {
            get
            {
                if (globalInventory == null)
                {
                    globalInventory = new Inventory(50);
                }

                return globalInventory;
            }
        }

        public Item[] Items;  // The items in the inventory

        /// <summary>
        /// Add an item to the inventory.
        /// </summary>
        /// <param name="item">The item to be added to the inventory. Set the amount in the Item object.</param>
        public void AddItem(Item item)
        {
            int leftToPlace = item.Amount;
            while (leftToPlace > 0)
            {
                int preferredSlot = -1;

                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i] != null)
                    {
                        if (Items[i].ItemData == item.ItemData && !Items[i].IsFull())
                        {
                            preferredSlot = i;
                            break;
                        }
                    }
                }

                if (preferredSlot == -1)
                {
                    for (int i = 0; i < Items.Length; i++)
                    {
                        if (Items[i] == null)
                        {
                            preferredSlot = i;
                            break;
                        }
                    }
                }

                if (preferredSlot == -1)
                    return;

                if (Items[preferredSlot] == null)
                    Items[preferredSlot] = new Item(item.ItemData);

                leftToPlace = Items[preferredSlot].AddAmount(leftToPlace);
            }
        }

        /// <summary>
        /// Remove the given item from the inventory.
        /// </summary>
        /// <param name="item">The item to be removed from the inventory. Set the amount in the Item object.</param>
        /// <returns>The amount that was not there but was needed.</returns>
        public int RemoveItem(Item item)
        {
            int leftToRemove = item.Amount;
            while (leftToRemove > 0)
            {
                int preferredSlot = -1;

                for (int i = Items.Length - 1; i > -1; i--)
                {
                    if (Items[i] != null)
                    {
                        if (Items[i].ItemData == item.ItemData)
                        {
                            preferredSlot = i;
                            break;
                        }
                    }
                }

                if (preferredSlot == -1)
                    return leftToRemove;

                if (Items[preferredSlot].Amount > leftToRemove)
                {
                    Items[preferredSlot].Amount -= leftToRemove;
                    return 0;
                }
                else
                {
                    leftToRemove -= Items[preferredSlot].Amount;
                    Items[preferredSlot] = null;
                }
            }
            return 0;
        }

        public int CanRemoveItem(Item item)
        {
            int counter = 0;
            foreach (Item i in Items)
            {
                if (i == null)
                {
                    continue;
                }

                if (item.ItemData == i.ItemData)
                {
                    counter += i.Amount;
                }
            }

            if (counter >= item.Amount)
            {
                return 0;
            }
            else
            {
                return item.Amount - counter;
            }
        }
    }
}