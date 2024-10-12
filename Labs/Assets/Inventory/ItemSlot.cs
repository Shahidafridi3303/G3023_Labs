using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Inventory owner = null;
    public Item itemInSlot = null;
    public Image ButtonImage;
    public TextMeshProUGUI itemText;

//#if UNITY_EDITOR
    //Called in editor when things change on this object //
    public void OnValidate()
    {
        Refresh();
    }
//#endif
    public void Refresh()
    {
        if (itemInSlot != null)
        {
            ButtonImage.sprite = itemInSlot.sprite;
            itemText.text = itemInSlot.name;
            ButtonImage.gameObject.SetActive(true);
        }
        else
        {
            ButtonImage.sprite = null;
            itemText.text = "";
            ButtonImage.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        Refresh();
    }

    public void UseItemInSlot(BattleCharacter target)
    {
        if (itemInSlot != null)
        {
            itemInSlot.Use(target);
        }
    }
}
