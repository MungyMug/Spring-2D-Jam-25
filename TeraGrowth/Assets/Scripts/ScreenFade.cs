using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDurationBlack = 2f;
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeFromBlack()
    {
        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
        gameObject.SetActive(false);
    }

    private IEnumerator FadeToBlack()
    {
        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (timer < fadeDurationBlack)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDurationBlack);
            yield return null;
        }

        fadeImage.color = endColor;
        gameObject.SetActive(false);
    }

    public void TriggerFadeToBlack()
    {
        StartCoroutine(FadeToBlack());
    }

    public void StartFade()
    {
        StartCoroutine(FadeFromBlack());
    }
}