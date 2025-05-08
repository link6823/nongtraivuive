using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public int slotID;
    public Inventory inventory;

    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    public GameObject highlight;

    public FiLowG_CayCuoc CayCuoc;
    public bool CayCuoc_Active;
    void Start()
    {
        CayCuoc = FindObjectOfType<FiLowG_CayCuoc>();
    }

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }

    void Update()
    {

        if (highlight != null)
        {
            if (highlight.activeSelf)
            {
                CayCuoc.Number_Holding = slotID;
            }
            else if (CayCuoc.Number_Holding == slotID)
            {
                CayCuoc.Number_Holding = -1;
            }
        }
    }


}
