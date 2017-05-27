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
        ItemData.CreateItemDatas();
        HexAction.Init();
        HexType.Init();

        GenerateMap();
    }

    public GameObject HexPrefab;
	public List<GameObject> Hexes;

    public int NumRows = 10;
    public int NumCols = 15;

    /// <summary>
    /// Generates the Map
    /// </summary>
	public void GenerateMap()
    {
		Hexes = new List<GameObject> ();

        for (int col = 0; col < NumCols; col++)
        {
            for (int row = 0; row < NumRows; row++)
            {
                Hex h = new Hex(col, row);

                if (h.Q == 0 && h.R == 0)
                {
                    h.Name = "Cell";
                }  
                else
                    h.Name = "Void";

                Vector3 pos = h.PositionFromCamera(Camera.main.transform.position, NumRows, NumCols);

                GameObject HexGO = Instantiate(HexPrefab, pos, Quaternion.identity, this.transform);
                HexGO.GetComponent<HexComponent>().Hex = h;
                HexGO.GetComponent<HexComponent>().HexMap = this;
                Renderer r = HexGO.transform.Find("HexModel").GetComponent<Renderer>();
                r.material = h.Type.Material;

				Hexes.Add (HexGO);
            }
        }
    }

	public void UpdateMaterials()
	{
		foreach (GameObject hex in Hexes)
		{
			hex.transform.Find ("HexModel").GetComponent<Renderer> ().material = hex.GetComponent<HexComponent> ().Hex.Type.Material;
		}
	}
}
