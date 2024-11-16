using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;

    PartyMemberUI[] memberSlots;
    List<Pokemon> pokemons;

    public void Init()
    {
        memberSlots = GetComponentsInChildren<PartyMemberUI>();
    }

    public void SetPartyData(List<Pokemon> pokemons)
    {
        this.pokemons = pokemons;

        for (int i = 0; i < memberSlots.Length; i++)
        {
            if (i < pokemons.Count)
                memberSlots[i].SetData(pokemons[i]);
            else
                memberSlots[i].gameObject.SetActive(false);
        }
        messageText.text = "Choose a Pokemon";

        Debug.Log("Total Pokemons: " + pokemons.Count);
    }

    public void UpdateMemberSelection(int selectedMember)
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            if (i == selectedMember)
                memberSlots[i].SetSelected(true);
            else
                memberSlots[i].SetSelected(false);
        }
    }

    //public void SetPartyData(List<Pokemon> pokemons)
    //{
    //    this.pokemons = pokemons;

    //    for (int i = 0; i < memberSlots.Length; i++)
    //    {
    //        if (i < pokemons.Count)
    //        {
    //            memberSlots[i].gameObject.SetActive(true);
    //            memberSlots[i].SetData(pokemons[i]);
    //        }
    //        else
    //        {
    //            memberSlots[i].gameObject.SetActive(false);
    //        }
    //    }
    //    messageText.text = "Choose a Pokemon";
    //}

    //public void UpdateMemberSelection(int selectedMember)
    //{
    //    for (int i = 0; i < memberSlots.Length; i++)
    //    {
    //        if (i < pokemons.Count) // Check that i is within bounds of pokemons
    //        {
    //            memberSlots[i].SetSelected(i == selectedMember);
    //        }
    //        else
    //        {
    //            memberSlots[i].SetSelected(false); // Deselect any out-of-bounds slots.
    //        }
    //    }
    //}

    public void SetMessageText(string message)
    {
        messageText.text = message;
    }
}

