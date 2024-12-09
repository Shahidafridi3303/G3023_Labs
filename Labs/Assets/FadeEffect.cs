using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public static FadeEffect Instance { get; private set; }

    [SerializeField] private Image blackImage; 
    [SerializeField] private float fadeDuration = 1f;

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

    private void Start()
    {
        // Test fade on start
        StartFadeEffect();
    }

    public void StartFadeEffect()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(Fade(1));

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(Fade(0));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = blackImage.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            SetImageAlpha(alpha);
            yield return null;
        }

        SetImageAlpha(targetAlpha);
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = blackImage.color;
        color.a = alpha;
        blackImage.color = color;
    }
}