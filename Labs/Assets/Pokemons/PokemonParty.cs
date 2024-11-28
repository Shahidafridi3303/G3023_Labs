using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class PokemonParty : MonoBehaviour
{
    [SerializeField] List<Pokemon> pokemons;
    public event Action OnPartyUpdated; // Event to notify updates in the party

    public List<Pokemon> Pokemons {
        get {
            return pokemons;
        }
        set
        {
            pokemons = value;
        }
    }

    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.Init();
        }
    }

    public Pokemon GetHealthyPokemon()
    {
        return pokemons.Where(x => x.HP > 0).FirstOrDefault();
    }

    public void AddPokemon(Pokemon newPokemon)
    {
        if (pokemons.Count < 16)
        {
            pokemons.Add(newPokemon);
            OnPartyUpdated?.Invoke(); // Notify listeners of the update
        }
        else
        {
            // Inventory full
        }
    }
}