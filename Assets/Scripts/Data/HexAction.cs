using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    public class HexAction
    {

        public HexAction(string name)
        {
            this.Name = name;
            Input = new List<Item>();
        }

        public static HexAction CreateRuneBasicBlank;
        public static HexAction CreateRuneBasicSpace;
        public static HexAction CreateRuneBasicStability;
        public static HexAction CreateRuneBasicOre;

        public static HexAction CreateClusterBasicExpansion;

        public string Name;
        public Item Output;
        private List<Item> Input;

        public static void Init()
        {
            CreateRuneBasicBlank = new HexAction("Create Basic Blank Rune").SetOutput(ItemData.RuneBasicBlank, 1);

            CreateRuneBasicSpace = new HexAction("Create Basic Space Rune");
            CreateRuneBasicSpace.SetOutput(ItemData.RuneBasicSpace, 1);
            CreateRuneBasicSpace.SetInput(ItemData.RuneBasicBlank, 1);

            CreateRuneBasicStability = new HexAction("Create Basic Stability Rune");
            CreateRuneBasicStability.SetOutput(ItemData.RuneBasicStability, 1);
            CreateRuneBasicStability.SetInput(ItemData.RuneBasicBlank, 1);

            CreateRuneBasicOre = new HexAction("Create Basic Ore Rune");
            CreateRuneBasicOre.SetOutput(ItemData.RuneBasicOre, 1);
            CreateRuneBasicOre.SetInput(ItemData.RuneBasicBlank, 1);

            CreateClusterBasicExpansion = new HexAction("Create Basic Expansion Cluster");
            CreateClusterBasicExpansion.SetOutput(ItemData.ClusterBasicExpansion, 1);
            CreateClusterBasicExpansion.AddInput(ItemData.RuneBasicSpace, 2);
            CreateClusterBasicExpansion.AddInput(ItemData.RuneBasicStability, 1);
        }

        public HexAction SetOutput(ItemData item, int amount)
        {
            Output = new Item(item).SetAmount(amount);
            return this;
        }

        public HexAction SetInput(ItemData item, int amount)
        {
            Input.Add(new Item(item).SetAmount(amount));
            return this;
        }

        public HexAction AddInput(ItemData item, int amount)
        {
            Input.Add(new Item(item).SetAmount(amount));
            return this;
        }

        public List<Item> GetInput()
        {
            return Input;
        }
    }
}
