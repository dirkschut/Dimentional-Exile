using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{

    public class ActionMouse : MonoBehaviour, IPointerDownHandler
    {

        public Data.Hex Hex;
        public Data.HexAction HexAction;

        public void OnPointerDown(PointerEventData eventData)
        {
            Hex.DoAction(HexAction);
        }
    }
}