using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMouse : MonoBehaviour {

    /// <summary>
    /// Calls the Hover function of the parent when the mouse enters
    /// </summary>
    private void OnMouseEnter()
    {
        this.transform.parent.gameObject.GetComponent<HexComponent>().Hex.Hover();
    }

    private void OnMouseDown()
    {
        if(!HexInfoComponent.mouseOver)
            this.transform.parent.gameObject.GetComponent<HexComponent>().Hex.Click();
    }
}
