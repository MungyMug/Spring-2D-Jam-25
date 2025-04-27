using UnityEngine;
using UnityEngine.UI;

public class PulseImage : MonoBehaviour
{
    [Header("Pulse Settings")]
    [SerializeField] private float pulseSpeed = 2f;
    [SerializeField] private float pulseAmount = 0.1f;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * scale;
    }
}
