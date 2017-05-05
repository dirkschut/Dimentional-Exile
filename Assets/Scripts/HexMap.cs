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

                if (h.Q == 0 && h.R == 0)
                {
                    h.name = "Cell";
                    GameObject.Find("HexInfo").GetComponent<HexInfoComponent>().Hex = h;
                }  
                else
                    h.name = "Void";

                Vector3 pos = h.PositionFromCamera(Camera.main.transform.position, NumRows, NumCols);

                GameObject HexGO = Instantiate(HexPrefab, pos, Quaternion.identity, this.transform);
                HexGO.GetComponent<HexComponent>().Hex = h;
                HexGO.GetComponent<HexComponent>().HexMap = this;
            }
        }
    }
}
