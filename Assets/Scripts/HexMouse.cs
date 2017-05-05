using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMouse : MonoBehaviour {

    /// <summary>
    /// Calls the Hover function of the parent when the mouse enters
    /// </summary>
    private void OnMouseEnter()
    {
        this.transform.parent.gameObject.GetComponent<HexComponent>().Hex.Hover();
    }
}
