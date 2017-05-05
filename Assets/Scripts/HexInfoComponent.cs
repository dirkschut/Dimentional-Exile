using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexInfoComponent : MonoBehaviour {

    public Hex Hex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Hex != null)
        {
            this.transform.FindChild("Name").GetComponent<Text>().text = Hex.name;
            this.transform.FindChild("Position").GetComponent<Text>().text = "Position: " + Hex.Q + ", " + Hex.R;
        }
	}
}
