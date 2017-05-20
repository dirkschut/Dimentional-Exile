using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexAction {

    public HexAction(string name)
    {
        this.Name = name;
    }

    public static HexAction CreateRuneBasicBlank;
    public static HexAction CreateTwoRuneBasicBlank;

    public string Name;
    public Item Output;

    public static void Init()
    {
        CreateRuneBasicBlank = new HexAction("Create Basic Blank Rune").SetOutput(ItemData.RuneBasicBlank, 1);
        CreateTwoRuneBasicBlank = new HexAction("Create Two Basic Blank Runes").SetOutput(ItemData.RuneBasicBlank, 2);
    }

    public HexAction SetOutput(ItemData item, int amount)
    {
        Output = new Item(item).setAmount(amount);
        return this;
    }

}
