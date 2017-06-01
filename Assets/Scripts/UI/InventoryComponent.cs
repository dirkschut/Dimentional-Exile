using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class InventoryComponent : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            InventoryCells = new GameObject[Data.Inventory.GlobalInventory.Items.Length];

            for (int i = 0; i < InventoryCells.Length; i++)
            {
                InventoryCells[i] = GameObject.Instantiate(InventoryCell, this.transform);
                InventoryCells[i].transform.Translate(new Vector3(i % 10 * 44, Mathf.Floor(i / 10) * -44, 0));
                InventoryCells[i].GetComponent<InventoryCellMouse>().Item = Data.Inventory.GlobalInventory.Items[i];
            }
        }

        public GameObject InventoryCell;
        public GameObject[] InventoryCells;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < InventoryCells.Length; i++)
            {
                if (Data.Inventory.GlobalInventory.Items[i] != null)
                {
                    InventoryCells[i].transform.Find("Sprite").GetComponent<Image>().enabled = true;
                    InventoryCells[i].transform.Find("Sprite").GetComponent<Image>().sprite = Data.Inventory.GlobalInventory.Items[i].ItemData.Texture;
                    InventoryCells[i].transform.Find("Amount").GetComponent<Text>().text = Data.Inventory.GlobalInventory.Items[i].Amount.ToString();
                    InventoryCells[i].GetComponent<InventoryCellMouse>().Item = Data.Inventory.GlobalInventory.Items[i];
                }
                else
                {
                    InventoryCells[i].transform.Find("Sprite").GetComponent<Image>().enabled = false;
                    InventoryCells[i].transform.Find("Amount").GetComponent<Text>().text = "";
                }
            }
        }
    }
}