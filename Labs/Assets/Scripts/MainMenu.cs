using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        gameController.LoadGame();
        SceneManager.LoadScene(1);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {

    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
