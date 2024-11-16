using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;

    PartyMemberUI[] memberSlots;
    private List<Pokemon> pokemons;

    public void Init()
    {
        memberSlots = GetComponentsInChildren<PartyMemberUI>();
        Debug.Log("1 Total Pokemons: " + memberSlots.Length);
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

        Debug.Log("2 Total Pokemons: " + pokemons.Count);
    }


    public void UpdateMemberSelection(int selectedMember)
    {
        for (int i = 0; i < memberSlots.Length; i++)
        {
            if (i < pokemons.Count && i == selectedMember)
                memberSlots[i].SetSelected(true);
            else
                memberSlots[i].SetSelected(false);
        }
    }

    public void SetMessageText(string message)
    {
        messageText.text = message;
    }
}

