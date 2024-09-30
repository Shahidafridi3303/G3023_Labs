using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Inventory owner = null;
    public Item itemInSlot = null;
    public Image itemIcon;

#if UNITY_EDITOR
    //Called in editor when things change on this object
    public void OnValidate()
    {
        //CheckSlot();
    }
#endif
    public void CheckSlot()
    {
        if (itemInSlot != null)
        {
            itemIcon.sprite = itemInSlot.sprite;
            itemIcon.gameObject.SetActive(true);
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        CheckSlot();
    }

    public void UseItemInSlot()
    {
        itemInSlot.Use(owner.character);
    }

    public void UseItemInSlot(BattleCharacter target)
    {
        itemInSlot.Use(target);
    }
}
