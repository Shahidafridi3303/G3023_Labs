using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle }

public class GameController : MonoBehaviour
{
    [SerializeField] Movement playerController;
    [SerializeField] RandomEncounters randomEncounters;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] GameObject SaveGameButton;
    [SerializeField] Camera worldCamera;

    GameState state;

    private void Awake()
    {
        PokemonDB.Init();
        MoveDB.Init();
    }

    private void Start()
    {
        randomEncounters.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
    }

    private void StartBattle()
    {
        state = GameState.Battle;
        playerController.SetVelocityZero();   
        battleSystem.gameObject.SetActive(true);
        SaveGameButton.SetActive(false);
        worldCamera.gameObject.SetActive(false);

        var playerParty = playerController.GetComponent<PokemonParty>();
        var wildPokemon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();

        var wildPokemonCopy = new Pokemon(wildPokemon.Base, wildPokemon.Level);

        battleSystem.StartBattle(playerParty, wildPokemonCopy);
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        SaveGameButton.SetActive(true);
        worldCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();

            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    SaveGame();
            //}

            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    SavingSystem.i.Load("saveSlot1");
            //}
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }

    public void LoadGame()
    {
        SavingSystem.i.Load("saveSlot1");
    }

    public void SaveGame()
    {
        SavingSystem.i.Save("saveSlot1");
    }
}
