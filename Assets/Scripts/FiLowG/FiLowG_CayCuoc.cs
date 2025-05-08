using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FiLowG_CayCuoc : MonoBehaviour
{
    public GameObject Plowable;
    public GameObject PutSeedable;
    public GameObject Got_Seed;
    public GameObject Plowed;
    internal int Number_Holding;

    internal Slot_UI Slot_UI;

    public Image Icon_0;
    public Image Icon_1;
    public Image Icon_2;
    public Image Icon_3;
    public Image Icon_4;
    public Image Icon_5;
    public Image Icon_6;
    public Image Icon_7;
    public Image Icon_8;
    public Image Icon_9;

    private Image selectedIcon;
    private bool quantity_Minus = false;

    void Start()
    {
        Slot_UI = FindAnyObjectByType<Slot_UI>();
        Number_Holding = -1;
    }

    void Update()
    {
        if (Number_Holding >= 0 && Number_Holding <= 9)
        {
            switch (Number_Holding)
            {
                case 0: selectedIcon = Icon_0; break;
                case 1: selectedIcon = Icon_1; break;
                case 2: selectedIcon = Icon_2; break;
                case 3: selectedIcon = Icon_3; break;
                case 4: selectedIcon = Icon_4; break;
                case 5: selectedIcon = Icon_5; break;
                case 6: selectedIcon = Icon_6; break;
                case 7: selectedIcon = Icon_7; break;
                case 8: selectedIcon = Icon_8; break;
                case 9: selectedIcon = Icon_9; break;
            }

            if (selectedIcon != null && selectedIcon.sprite != null)
            {
                if (selectedIcon.sprite.name == "Basic_tools_and_meterials_2")
                {
                    Plowable.SetActive(true);
                }
                else
                {
                    Plowable.SetActive(false);
                }

                if (selectedIcon.sprite.name == "free_24")
                {
                    PutSeedable.SetActive(true);
                    if (quantity_Minus)
                    {
                        Transform quantityTransform = selectedIcon.transform.parent.Find("Quantity");

                        if (quantityTransform != null)
                        {
                            TMP_Text quantityText = quantityTransform.GetComponent<TMP_Text>();

                            if (quantityText != null)
                            {
                                if (int.TryParse(quantityText.text, out int quantity))
                                {
                                    if (quantity > 0)
                                    {
                                        quantity--;
                                        quantityText.text = quantity.ToString();
                                        quantity_Minus = false;
                                    }
                                    if (quantity == 0)
                                    {
                                        quantityText.text = "";
                                        selectedIcon.sprite = null;

                                        UnityEngine.Color iconColor = selectedIcon.color;
                                        iconColor.a = 0f;
                                        selectedIcon.color = iconColor;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    PutSeedable.SetActive(false);
                }
            }
            else
            {
                Plowable.SetActive(false);
                PutSeedable.SetActive(false);
            }
        }
    }

    public void Plow()
    {
        if (!Plowed.activeSelf)
        {
            if (Plowable.activeSelf)
            {
                Plowed.SetActive(true);
            }
            else
            {
                Plowed.SetActive(false);
            }
        }
    }

    public void PutSeed()
    {
        if (PutSeedable.activeSelf && Plowed.activeSelf)
        {
            Got_Seed.SetActive(true);
            quantity_Minus = true;
        }
        else
        {
            Got_Seed.SetActive(false);
        }
    }
}
