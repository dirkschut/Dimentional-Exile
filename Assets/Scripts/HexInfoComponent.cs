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
            foreach(GameObject cell in InventoryCells)
            {
                Destroy(cell);
            }

            foreach(GameObject action in HexActions)
            {
                Destroy(action);
            }

            hex = value;

            InventoryCells = new GameObject[hex.Inventory.Items.Length];
            for (int i = 0; i < InventoryCells.Length; i++)
            {
                InventoryCells[i] = GameObject.Instantiate(InventoryCell, this.transform.Find("Inventory"));
                InventoryCells[i].transform.Translate(new Vector3(i % 4 * 44, Mathf.Floor(i / 4) * -44, 0));
                InventoryCells[i].GetComponent<InventoryCellMouse>().Item = hex.Inventory.Items[i];
            }

            HexActions = new GameObject[hex.Type.Actions.Count];
            int actionCounter = 0;
            foreach(HexAction action in hex.Type.Actions)
            {
                HexActions[actionCounter] = GameObject.Instantiate(HexAction, this.transform.Find("Actions").Find("Viewport").Find("Content"));
                HexActions[actionCounter].transform.Translate(new Vector3(0, actionCounter * -30, 0));
                HexActions[actionCounter].transform.Find("Text").GetComponent<Text>().text = action.Name;
                HexActions[actionCounter].GetComponent<ActionMouse>().Hex = hex;
                HexActions[actionCounter].GetComponent<ActionMouse>().HexAction = action;
                actionCounter++;
            }
            this.transform.Find("Actions").Find("Viewport").Find("Content").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 40 + actionCounter * 30);
        }
        get
        {
            return hex;
        }
    }

    public static bool mouseOver = false;  // If the mouse is over this panel, this variable is true

    public static GameObject MouseOverCell;

    public GameObject InventoryCell;
    public GameObject HexAction;

    public GameObject[] InventoryCells;
    public GameObject[] HexActions;

	/// <summary>
    /// Updates the info panel
    /// </summary>
	void Update () {
        if(Hex != null)
        {
            this.transform.Find("Position").GetComponent<Text>().text = "Position: " + Hex.Q + ", " + Hex.R;
            this.transform.Find("Type").GetComponent<Text>().text = "Type: " + Hex.Type.Name;

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

    public static void OnMouseEnterCell(GameObject Cell)
    {

    }
}
