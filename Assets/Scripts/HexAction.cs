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
	public static HexAction CreateRuneBasicSpace;
	public static HexAction CreateRuneBasicStability;

    public string Name;
    public Item Output;
	public Item Input;

    public static void Init()
    {
		CreateRuneBasicBlank = new HexAction("Create Basic Blank Rune").SetOutput(ItemData.RuneBasicBlank, 1);
		CreateTwoRuneBasicBlank = new HexAction("Create Two Basic Blank Runes").SetOutput(ItemData.RuneBasicBlank, 2);

		CreateRuneBasicSpace = new HexAction("Create Basic Space Rune");
		CreateRuneBasicSpace.SetOutput (ItemData.RuneBasicSpace, 1);
		CreateRuneBasicSpace.SetInput (ItemData.RuneBasicBlank, 1);

		CreateRuneBasicStability = new HexAction("Create Basic Stability Rune");
		CreateRuneBasicStability.SetOutput (ItemData.RuneBasicStability, 1);
		CreateRuneBasicStability.SetInput (ItemData.RuneBasicBlank, 1);
    }

    public HexAction SetOutput(ItemData item, int amount)
    {
        Output = new Item(item).setAmount(amount);
        return this;
    }

	public HexAction SetInput(ItemData item, int amount)
	{
		Input = new Item (item).setAmount(amount);
		return this;
	}

}
