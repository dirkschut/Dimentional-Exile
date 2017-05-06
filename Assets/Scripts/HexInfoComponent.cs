using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This component manages the Hex Info panel content and interaction
/// </summary>
public class HexInfoComponent : MonoBehaviour {

    public Hex Hex;  // Contains thecurrent hex

    public static bool mouseOver = false;  // If the mouse is over this panel, this variable is true
	
	/// <summary>
    /// Updates the info panel
    /// </summary>
	void Update () {
		if(Hex != null)
        {
            this.transform.FindChild("Name").GetComponent<Text>().text = Hex.name;
            this.transform.FindChild("Position").GetComponent<Text>().text = "Position: " + Hex.Q + ", " + Hex.R;
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
