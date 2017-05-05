using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour
{

    public Hex Hex;
    public HexMap HexMap;

    /// <summary>
    /// Check if the position in the unity world space needs to be ajusted
    /// </summary>
    public void UpdatePosition()
    {
        this.transform.position = Hex.PositionFromCamera(Camera.main.transform.position, HexMap.NumRows, HexMap.NumCols);
    }

}
