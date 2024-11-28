using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool LoadSavedGame { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ContinueGame()
    {
        LoadSavedGame = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

        // Start a coroutine to wait for the GameController
        StartCoroutine(WaitForGameControllerAndLoad());
    }

    private IEnumerator WaitForGameControllerAndLoad()
    {
        yield return new WaitForSeconds(0.2f);

        GameController gameController = null;

        while (gameController == null)
        {
            gameController = FindObjectOfType<GameController>();
            if (gameController == null)
            {
                yield return null; // Wait for the next frame
            }
        }

        Debug.Log("GameController found. Calling LoadGame...");
        try
        {
            gameController.LoadGame();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error while calling LoadGame: {ex.Message}\n{ex.StackTrace}");
        }
    }
}