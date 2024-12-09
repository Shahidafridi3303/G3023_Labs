using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }

    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    [SerializeField] private GameObject Image;
    [SerializeField] private float time;

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

    public void StartFading()
    {
        Image.gameObject.SetActive(true);
        _startingSceneTransition.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(time);
        _startingSceneTransition.SetActive(false);
        Image.gameObject.SetActive(false);
        _endingSceneTransition.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(time);
        _endingSceneTransition.SetActive(false);
    }
}
