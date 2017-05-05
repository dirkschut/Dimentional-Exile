using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// Generates the Map
    /// </summary>
	public void GenerateMap()
    {
        for (int col = 0; col < 10; col++)
        {
            for (int row = 0; row < 10; row++)
            {
                GameObject HexGO = Instantiate(HexPrefab, new Vector3(col, 0, row), Quaternion.identity, this.transform);
            }
        }
    }
}
