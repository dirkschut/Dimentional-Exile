using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class HexUpgrade
    {
        public HexUpgrade(HexType hexType)
        {
            this.HexType = hexType;
            Input = new List<Item>();
        }

        public HexType HexType;
        public List<Item> Input;

        public HexUpgrade AddInput(Item input)
        {
            Input.Add(input);
            return this;
        }

        public HexUpgrade SetInput(Item input)
        {
            Input = new List<Item>();
            Input.Add(input);
            return this;
        }

    }
}