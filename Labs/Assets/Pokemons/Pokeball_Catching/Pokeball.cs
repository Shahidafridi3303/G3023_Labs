using UnityEngine;
using TMPro;

public class Pokeball : MonoBehaviour
{
    public Pokemon pokemon;
    [SerializeField] private TextMeshProUGUI Item_Info, _pickup_UI;

    public void Start()
    {
        // Set text to display Pokémon's name and level
        _pickup_UI.gameObject.SetActive(false);
        Item_Info.gameObject.SetActive(false);

        if (pokemon != null)
        {
            pokemon.Init();
            Item_Info.text = $"{pokemon.Base.Name} Lv {pokemon.Level}";
        }
    }

    public Pokemon GetPokemon()
    {
        if (pokemon == null)
        {
            Debug.LogWarning("In Pokéball, Pokémon not assigned");
            return null;
        }

        return pokemon;
    }

    public void Set_UIinfo(bool setActive)
    {
        _pickup_UI.gameObject.SetActive(setActive);
        Item_Info.gameObject.SetActive(setActive);
    }
}