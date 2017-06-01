using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    /// <summary>
    /// The Item object.
    /// </summary>
    public class Item
    {

        /// <summary>
        /// Creates an Item object with the given ItemData.
        /// </summary>
        /// <param name="itemData"></param>
        public Item(ItemData itemData)
        {
            this.ItemData = itemData;
        }

        public ItemData ItemData;  // The data of the item

        public int Amount = 0;  // The amount of items in the stack

        /// <summary>
        /// Add the amount given to the Item. Use only while the item is in a cell.
        /// </summary>
        /// <param name="amount">The amount of items that should be added</param>
        /// <returns>Overflow</returns>
        public int AddAmount(int amount)
        {
            Amount += amount;

            if (Amount > ItemData.StackLimit)
            {
                int extra = Amount - ItemData.StackLimit;
                Amount = ItemData.StackLimit;
                return extra;
            }

            return 0;
        }

        /// <summary>
        /// Remove the given amount from the item.
        /// </summary>
        /// <param name="amount">The amount to be removed.</param>
        /// <returns>Items that were needed but where not there.</returns>
        public int RemoveAmount(int amount)
        {
            if (amount > Amount)
            {
                Amount -= amount;
                return 0;
            }

            int needed = amount - Amount;
            Amount = 0;
            return needed;
        }

        /// <summary>
        /// Set the amount of items in the Item. Don't use while in a cell because there is no checks for overflow.
        /// </summary>
        /// <param name="amount">The amount to be set.</param>
        /// <returns>The Item object</returns>
        public Item SetAmount(int amount)
        {
            Amount = amount;
            return this;
        }

        /// <summary>
        /// Check if the item is full
        /// </summary>
        /// <returns>Wether the item is full.</returns>
        public bool IsFull()
        {
            if (Amount < ItemData.StackLimit)
                return false;

            return true;
        }
    }
}