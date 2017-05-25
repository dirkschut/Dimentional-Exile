using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {

	public List<HexInfoComponent> Windows;

    public GameObject HexInfoWindow;

    public static bool MouseOverUI = false;

	// Use this for initialization
	void Start ()
    {
		Windows = new List<HexInfoComponent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		bool mouseOverUI = false;
		foreach(HexInfoComponent g in Windows)
        {
			if (!g) {
				Windows.Remove (g);
				Update();
				break;
			}

			if (g.MouseOver) {
				mouseOverUI = true;
			}
        }
		MouseOverUI = mouseOverUI;
	}

	public void RegisterWindow(HexInfoComponent window)
    {
        Windows.Add(window);
    }

    public void MakeHexInfoWindow(Hex h)
    {
        GameObject.Instantiate(HexInfoWindow, GameObject.Find("Canvas").transform).GetComponent<HexInfoComponent>().Hex = h;
    }
}
