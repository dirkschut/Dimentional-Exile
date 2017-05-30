using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace UI
{

    /// <summary>
    /// This component manages the Hex Info panel content and interaction
    /// </summary>
    public class HexInfoComponent : MonoBehaviour
    {

        private Data.Hex hex;
        public Data.Hex Hex
        {
            set
            {
                foreach (GameObject action in HexActions)
                {
                    Destroy(action);
                }

                hex = value;

                HexActions = new GameObject[hex.Type.Actions.Count];
                int actionCounter = 0;
                foreach (Data.HexAction action in hex.Type.Actions)
                {
                    HexActions[actionCounter] = GameObject.Instantiate(HexAction, this.transform.Find("Actions").Find("Viewport").Find("Content"));
                    HexActions[actionCounter].transform.Translate(new Vector3(0, actionCounter * -30, 0));
                    HexActions[actionCounter].transform.Find("Text").GetComponent<Text>().text = action.Name;
                    HexActions[actionCounter].GetComponent<ActionMouse>().Hex = hex;
                    HexActions[actionCounter].GetComponent<ActionMouse>().HexAction = action;
                    actionCounter++;
                }
                this.transform.Find("Actions").Find("Viewport").Find("Content").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 40 + actionCounter * 30);
                this.transform.Find("Upgrade").GetComponent<HexUpgrade>().Hex = hex;
            }
            get
            {
                return hex;
            }
        }

        public static GameObject MouseOverCell;

        public GameObject HexAction;

        public GameObject[] HexActions;

        void Start()
        {

        }

        /// <summary>
        /// Updates the info panel
        /// </summary>
        void Update()
        {
            if (Hex != null)
            {
                this.transform.Find("Position").GetComponent<Text>().text = "Position: " + Hex.Q + ", " + Hex.R;
                this.transform.Find("Type").GetComponent<Text>().text = "Type: " + Hex.Type.Name;
            }
        }

        public static void OnMouseEnterCell(GameObject Cell)
        {

        }
    }
}