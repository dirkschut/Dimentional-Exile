using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMouse : MonoBehaviour, IPointerDownHandler {

    public Hex Hex;
    public HexAction HexAction;

    public void OnPointerDown(PointerEventData eventData)
    {
        Hex.DoAction(HexAction);
    }
}
