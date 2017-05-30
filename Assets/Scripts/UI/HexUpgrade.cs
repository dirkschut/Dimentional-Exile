using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{

    public class HexUpgrade : MonoBehaviour, IPointerClickHandler
    {

        public Data.Hex Hex;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Hex.Type.UpgradeTo != null)
            {
                Hex.Type = Hex.Type.UpgradeTo;
                GameObject.Find("Hexmap").GetComponent<Data.HexMap>().UpdateMaterials();
            }
        }

    }
}