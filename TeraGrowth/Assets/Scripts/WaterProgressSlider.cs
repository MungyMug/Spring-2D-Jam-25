using UnityEngine;
using UnityEngine.UI;

public class WaterProgressSlider : MonoBehaviour
{
    [Header("Slider Settings")]
    [SerializeField] private Slider progressSlider;

    [Header("Watering Can Reference")]
    [SerializeField] private WateringCanMover wateringCanMover; // Your watering can script reference

    private void Update()
    {
        if (wateringCanMover == null || progressSlider == null)
            return;

        // Calculate progress
        float progress = (float)wateringCanMover.CurrentSuccessCount() / wateringCanMover.RequiredSuccessCount();
        progress = Mathf.Clamp01(progress); // Always keep it between 0 and 1

        // Update slider
        progressSlider.value = progress;
    }
}
