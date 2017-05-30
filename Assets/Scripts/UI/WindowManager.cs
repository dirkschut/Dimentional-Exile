using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    public class WindowManager : MonoBehaviour
    {

        public List<UIComponent> Windows;

        public GameObject HexInfoWindow;

        public static bool MouseOverUI = false;

        // Use this for initialization
        void Start()
        {
            Windows = new List<UIComponent>();
        }

        // Update is called once per frame
        void Update()
        {
            bool mouseOverUI = false;
            foreach (UIComponent window in Windows)
            {
                if (!window)
                {
                    Windows.Remove(window);
                    Update();
                    break;
                }

                if (window.MouseOver)
                {
                    mouseOverUI = true;
                }
            }
            MouseOverUI = mouseOverUI;
        }

        public void RegisterWindow(UIComponent window)
        {
            Windows.Add(window);
        }

        public void MakeHexInfoWindow(Data.Hex h)
        {
            GameObject.Instantiate(HexInfoWindow, GameObject.Find("Canvas").transform).GetComponent<HexInfoComponent>().Hex = h;
        }
    }
}