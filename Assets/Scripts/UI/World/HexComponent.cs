using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.World
{

    /// <summary>
    /// This component manages the interaction of the hex with the unity game world
    /// </summary>
    public class HexComponent : MonoBehaviour
    {

        public Data.Hex Hex;
        public Data.HexMap HexMap;

        /// <summary>
        /// Check if the position in the unity world space needs to be ajusted
        /// </summary>
        public void UpdatePosition()
        {
            this.transform.position = Hex.PositionFromCamera(Camera.main.transform.position, HexMap.NumRows, HexMap.NumCols);
        }

    }
}
