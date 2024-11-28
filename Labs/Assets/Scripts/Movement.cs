using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour, ISavable
{
    [SerializeField] float moveSpeed = 4;

    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    public void HandleUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 inputVector = new Vector2(x, y);
        Vector3 velocity = inputVector * moveSpeed;

        rb.velocity = velocity;
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector3.zero;
    }

    public object CaptureState()
    {
        var saveData = new PlayerSaveData()
        {
            position = new float[] { transform.position.x, transform.position.y },
            pokemons = GetComponent<PokemonParty>().Pokemons.Select(p => p.GetSaveData()).ToList()
        };

        return saveData;
    }

    public void RestoreState(object state)
    {
        var saveData = (PlayerSaveData)state;

        var pos = saveData.position;
        transform.position = new Vector3(pos[0], pos[1]);

        // Restore Party
        GetComponent<PokemonParty>().Pokemons = saveData.pokemons.Select(s => new Pokemon(s)).ToList();
    }
}

[Serializable]
public class PlayerSaveData
{
    public float[] position;
    public List<PokemonSaveData> pokemons;
}