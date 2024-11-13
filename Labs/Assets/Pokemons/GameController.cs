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
    [SerializeField] Camera worldCamera;

    GameState state;

    private void Start()
    {
        randomEncounters.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
    }

    private void StartBattle()
    {
        state = GameState.Battle;
        playerController.SetVelocityZero();    // set player speed 0;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}
