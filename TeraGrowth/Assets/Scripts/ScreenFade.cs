using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;

    private void Awake()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            fadeImage.color = new Color(c.r, c.g, c.b, 0f);
        }
    }

    public void TriggerFadeOut()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        Color startColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        fadeImage.color = startColor;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;

        ResetFade();
    }

    private void ResetFade()
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            fadeImage.color = new Color(c.r, c.g, c.b, 0f);
        }

        gameObject.SetActive(false);
    }
}
