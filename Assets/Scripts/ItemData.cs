using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The data of the items
/// </summary>
public class ItemData
{

    /// <summary>
    /// Creates an ItemData object and adds it to the Dictionary.
    /// </summary>
    /// <param name="name">The name of the ItemData.</param>
    public ItemData(string name)
    {
        ItemDatas.Add(name, this);
        this.Name = name;
    }

    public static Dictionary<string, ItemData> ItemDatas;  // The dictionary of all the itemdatas

    public string Name;  // The name of the itemdata
    public Sprite Texture;  // The sprite of the itemdata
    public int StackLimit = 99;  // The maximum number of items in an Item object

    /// <summary>
    /// Creates all the itemdatas in the game
    /// </summary>
    public static void CreateItemDatas()
    {
        ItemDatas = new Dictionary<string, ItemData>();

        new ItemData("Basic Blank Rune").SetImage("Basic Blank Rune").SetStackLimit(10);
    }

    /// <summary>
    /// Set the sprite of the item
    /// </summary>
    /// <param name="imageName">The sprite to use</param>
    /// <returns>The ItemData object</returns>
    public ItemData SetImage(string imageName)
    {
        Texture = Resources.Load<Sprite>("Images/" + imageName);
        return this;
    }

    /// <summary>
    /// Sets the Stack Limit
    /// </summary>
    /// <param name="stackLimit">The Stack Limit</param>
    /// <returns>The ItemData object.</returns>
    public ItemData SetStackLimit(int stackLimit)
    {
        this.StackLimit = stackLimit;
        return this;
    }

}
