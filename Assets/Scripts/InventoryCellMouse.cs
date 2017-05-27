using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCellMouse : MonoBehaviour, IPointerEnterHandler {

    public Item Item;

    public void OnPointerEnter(PointerEventData eventData)
    {
		if (Item == null)
            return;

        GameObject.Find("HoverInfo1").GetComponent<Text>().text = "Name: " + Item.ItemData.Name;
        GameObject.Find("HoverInfo2").GetComponent<Text>().text = "Amount: " + Item.Amount;
    }
}
