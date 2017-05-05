using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the HexMap
/// </summary>
public class HexMap : MonoBehaviour
{

	/// <summary>
    /// Instatiate the HexMap script
    /// </summary>
	void Start ()
    {
        GenerateMap();
	}

    public GameObject HexPrefab;

    public int NumRows = 10;
    public int NumCols = 15;

    /// <summary>
    /// Generates the Map
    /// </summary>
	public void GenerateMap()
    {
        for (int col = 0; col < NumCols; col++)
        {
            for (int row = 0; row < NumRows; row++)
            {
                Hex h = new Hex(col, row);
                Vector3 pos = h.Position();

                GameObject HexGO = Instantiate(HexPrefab, pos, Quaternion.identity, this.transform);
            }
        }
    }
}
