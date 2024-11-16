using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public Pokemon pokemon;

    public Pokemon GetPokemon()
    {
        if (pokemon == null)
        {
            Debug.Log("In Pokeball Pokemon not assigned");
            return null;
        }

        pokemon.Init();
        return pokemon;
    }
}
