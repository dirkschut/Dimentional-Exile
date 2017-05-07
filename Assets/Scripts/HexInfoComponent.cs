using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This component manages the Hex Info panel content and interaction
/// </summary>
public class HexInfoComponent : MonoBehaviour {

    private Hex hex;
    public Hex Hex
    {
        set
        {
            hex = value;
            InventoryCells = new GameObject[hex.Inventory.Items.Length];
            for (int i = 0; i < InventoryCells.Length; i++)
            {
                InventoryCells[i] = GameObject.Instantiate(InventoryCell, this.transform.Find("Inventory"));
                InventoryCells[i].transform.Translate(new Vector3(i % 4 * 44, Mathf.Floor(i / 4) * -44, 0));
            }
        }
        get
        {
            return hex;
        }
    }

    public static bool mouseOver = false;  // If the mouse is over this panel, this variable is true

    public GameObject InventoryCell;

    public GameObject[] InventoryCells;

	/// <summary>
    /// Updates the info panel
    /// </summary>
	void Update () {
        if(Hex != null)
        {
            this.transform.FindChild("Name").GetComponent<Text>().text = Hex.Name;
            this.transform.FindChild("Position").GetComponent<Text>().text = "Position: " + Hex.Q + ", " + Hex.R;
            this.transform.FindChild("Type").GetComponent<Text>().text = "Type: " + Hex.Type;

            for (int i = 0; i < InventoryCells.Length; i++)
            {
                if (Hex.Inventory.Items[i] != null)
                {
                    InventoryCells[i].transform.Find("Sprite").GetComponent<Image>().sprite = Hex.Inventory.Items[i].ItemData.Texture;
                    InventoryCells[i].transform.Find("Amount").GetComponent<Text>().text = Hex.Inventory.Items[i].Amount.ToString();
                }
                else
                {
                    InventoryCells[i].transform.Find("Sprite").GetComponent<Image>().sprite = null;
                    InventoryCells[i].transform.Find("Amount").GetComponent<Text>().text = "";
                }
            }
        }
	}

    /// <summary>
    /// Gets called when the mouse enters the info panel
    /// </summary>
    public void OnMouseEnter()
    {
        mouseOver = true;
    }

    /// <summary>
    /// Gets called when the mouse leaves the info panel
    /// </summary>
    public void OnMouseExit()
    {
        mouseOver = false;
    }
}
