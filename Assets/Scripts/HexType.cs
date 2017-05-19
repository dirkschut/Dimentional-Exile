using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexType {

    public HexType(string name)
    {
        this.Name = name;
    }

    public static HexType Void;
    public static HexType Cell;

    public string Name;
    public Material Material;

    public static void Init()
    {
        Void = new HexType("Void").SetMaterial("Void");
        Cell = new HexType("Cell").SetMaterial("Cell");
    }

    public HexType SetMaterial(string matName)
    {
        Material = Resources.Load<Material>("Materials/Hexes/" + matName);
        return this;
    }

}
