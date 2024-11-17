using System;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    Rigidbody2D body;
    public float distanceTravelledSinceLastEncounter = 0;

    [Range(0f, 100000f)]
    [SerializeField]
    public float minEncounterDistance = 2;

    public event Action OnEncountered;

    private Pokeball nearbyPokeball; // Reference to the current Pokeball

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (nearbyPokeball != null && Input.GetKeyDown(KeyCode.E))
        {
            PokemonParty pokemonParty = GetComponent<PokemonParty>();
            if (pokemonParty != null)
            {
                Pokemon caughtPokemon = nearbyPokeball.GetPokemon();
                if (caughtPokemon != null)
                {
                    pokemonParty.AddPokemon(caughtPokemon);
                    Debug.Log($"Caught {caughtPokemon.Base.Name}!");
                }
            }
            Destroy(nearbyPokeball.gameObject);
            nearbyPokeball = null; // Clear the reference
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            // Handle EncounterArea logic
            EncounterArea encounterZone = collision.GetComponent<EncounterArea>();
            if (encounterZone != null)
            {
                if (body.velocity.sqrMagnitude > 0)
                {
                    distanceTravelledSinceLastEncounter += body.velocity.magnitude * Time.fixedDeltaTime;

                    while (distanceTravelledSinceLastEncounter > minEncounterDistance)
                    {
                        distanceTravelledSinceLastEncounter -= minEncounterDistance;

                        if (encounterZone.RollEncounter())
                        {
                            OnEncountered?.Invoke();
                        }
                    }
                }
            }

            // Handle Pokeball logic
            Pokeball pokeball = collision.GetComponent<Pokeball>();
            if (pokeball != null)
            {
                nearbyPokeball = pokeball; // Save reference
                pokeball.Set_UIinfo(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Pokeball pokeball = collision.GetComponent<Pokeball>();
        if (pokeball != null)
        {
            pokeball.Set_UIinfo(false);
            if (nearbyPokeball == pokeball)
            {
                nearbyPokeball = null; // Clear reference when leaving
            }
        }
    }
}
