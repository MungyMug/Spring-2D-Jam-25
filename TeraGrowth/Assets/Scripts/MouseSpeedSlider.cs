using UnityEngine;
using UnityEngine.UI;

public class MouseSpeedSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    [SerializeField] private Slider speedSlider;

    [Header("Shaker Reference")]
    [SerializeField] private Shaker shaker; // Reference to Shaker.cs

    private void Update()
    {
        if (shaker == null || speedSlider == null)
            return;

        float progress = (float)shaker.CurrentClickCount() / shaker.RequiredClickCount();
        progress = Mathf.Clamp01(progress);

        speedSlider.value = progress;
    }
}
