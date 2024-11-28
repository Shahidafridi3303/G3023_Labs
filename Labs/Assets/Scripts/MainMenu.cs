using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Ensure GameManager is instantiated
        if (GameManager.Instance == null)
        {
            GameObject gameManagerObj = new GameObject("GameManager");
            gameManagerObj.AddComponent<GameManager>();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        // Ensure GameManager is instantiated
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is not initialized.");
            return;
        }

        GameManager.Instance.ContinueGame();
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        // Credits logic here
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
