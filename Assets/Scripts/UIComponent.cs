using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public bool MouseOver = false;
    public bool Registered = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Registered)
        {
            GameObject.Find("WindowManager").GetComponent<WindowManager>().RegisterWindow(this);
        }
        MouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.Translate(new Vector3(eventData.delta.x, eventData.delta.y, 0));
    }
}
