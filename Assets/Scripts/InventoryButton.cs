using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler {

	public GameObject InventoryWindow;

	public void OnPointerClick (PointerEventData eventData)
	{
		GameObject.Instantiate (InventoryWindow, GameObject.Find("Canvas").transform);
	}

}
