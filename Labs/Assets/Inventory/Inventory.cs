using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots;

    // Start is called before the first frame update
    void Start()
    {
        itemSlots = new List<ItemSlot>();
        ItemSlot[] slots = GetComponentsInChildren<ItemSlot>();
        itemSlots.AddRange(slots);
    }

}
