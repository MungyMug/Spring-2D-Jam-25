using UnityEngine;
using UnityEngine.EventSystems;

public class Shaker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Click Settings")]
    [SerializeField] private int requiredClickCount = 6;
    [SerializeField] private float maxClickInterval = 0.5f; // Maximum allowed time between clicks

    [SerializeField] GameObject clickImage;

    private bool isInsideArea = false;
    private int clickCount = 0;
    private float clickTimer = 0f;
    private bool eventComplete = false;
    private bool isWiggling = false;

    AudioManager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (!isInsideArea)
            return;

        if (gameObject.CompareTag("Cheats"))
        {
            // Detect mouse button down
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.mouseScrollDelta.y != 0f)
            {
                clickCount++;
                clickImage.SetActive(false);
                clickTimer = maxClickInterval; // Reset timer after each click
                Debug.Log("Click detected! Current clicks: " + clickCount);

                StartCoroutine(WiggleOnce());

                if (clickCount >= requiredClickCount)
                {
                    CompleteFertilizing();
                }
            }

            // Timer counts down
            if (clickTimer > 0f)
            {
                clickTimer -= Time.deltaTime;
                if (clickTimer <= 0f)
                {
                    // If timer runs out between clicks, reset
                    clickCount = 0;
                    Debug.Log("Click streak reset.");
                }
            }
        }
        else
        {
            // Detect mouse button down
            if (Input.GetMouseButtonDown(0))
            {
                clickCount++;
                clickImage.SetActive(false);
                clickTimer = maxClickInterval; // Reset timer after each click
                Debug.Log("Click detected! Current clicks: " + clickCount);

                StartCoroutine(WiggleOnce());

                if (clickCount >= requiredClickCount)
                {
                    CompleteFertilizing();
                }
            }

            // Timer counts down
            if (clickTimer > 0f)
            {
                clickTimer -= Time.deltaTime;
                if (clickTimer <= 0f)
                {
                    // If timer runs out between clicks, reset
                    clickCount = 0;
                    Debug.Log("Click streak reset.");
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isInsideArea = true;
        Debug.Log("Mouse entered fertilizer zone");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isInsideArea = false;
        clickCount = 0;
        Debug.Log("Mouse exited fertilizer zone");
    }

    private void CompleteFertilizing()
    {
        eventComplete = true;
        Debug.Log("Fertilizer poured!");
        clickCount = 0;
    }

    private System.Collections.IEnumerator WiggleOnce()
    {
        if (isWiggling)
            yield break;

        if (gameObject.CompareTag("Frog"))
        {
            audiomanager.PlaySFX(audiomanager.croak);
        }
        else 
        {
            audiomanager.PlaySFX(audiomanager.shake);
        }

        isWiggling = true;

        Quaternion originalRotation = transform.rotation;
        float wiggleAmount = 15f;
        float wiggleSpeed = 5f;

        // Wiggle right
        float elapsed = 0f;
        while (elapsed < 0.1f)
        {
            transform.rotation = originalRotation * Quaternion.Euler(0, 0, Mathf.Sin(elapsed * wiggleSpeed * Mathf.PI) * wiggleAmount);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Wiggle left
        elapsed = 0f;
        while (elapsed < 0.1f)
        {
            transform.rotation = originalRotation * Quaternion.Euler(0, 0, Mathf.Sin(elapsed * wiggleSpeed * Mathf.PI) * -wiggleAmount);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;
        isWiggling = false;
    }

    public bool EventComplete()
    {
        return eventComplete;
    }

    public void ResetEvent()
    {
        eventComplete = false;
    }

    public int CurrentClickCount()
    {
        return clickCount;
    }

    public int RequiredClickCount()
    {
        return requiredClickCount;
    }

}
