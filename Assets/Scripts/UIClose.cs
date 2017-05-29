using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIClose : MonoBehaviour, IPointerDownHandler {

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(transform.parent.gameObject);
    }
}
