using UnityEngine;
using System.Collections;

public class WateringCanMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 3f;
    [SerializeField] private float stopDuration = 2f;

    [Header("Watering Settings")]
    [SerializeField] private int sucessCount = 0;
    [SerializeField] private int requiredSucessCount = 3;
    [SerializeField] private float clickCooldown = 3f;

    [SerializeField] GameObject clickImage;

    private Vector3 startPosition;
    private bool isMoving = true;
    private bool canClick = true;

    AudioManager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = startPosition + new Vector3(offset, 0f, 0f);
    }

    public void StopMovement()
    {
        if (isMoving && canClick)
        {
            WaterSucess();
            StartCoroutine(StopAndResumeCoroutine());
            StartCoroutine(ClickCooldownCoroutine());
        }
    }

    private IEnumerator StopAndResumeCoroutine()
    {
        isMoving = false;
        yield return new WaitForSeconds(stopDuration);
        isMoving = true;
    }
    private IEnumerator ClickCooldownCoroutine()
    {
        canClick = false;
        yield return new WaitForSeconds(clickCooldown);
        canClick = true;
    }


    private void WaterSucess()
    {
        float xPos = GetComponent<RectTransform>().anchoredPosition.x;

        if (xPos >= 38f && xPos <= 158f)
        {
            clickImage.SetActive(false);
            audiomanager.PlaySFX(audiomanager.water);
            sucessCount++;
        }
    }

    public bool EventComplete()
    {
        return sucessCount >= requiredSucessCount;
    }

    public int CurrentSuccessCount()
    {
        return sucessCount;
    }

    public int RequiredSuccessCount()
    {
        return requiredSucessCount;
    }

    public void ResetWaterEvent()
    {
        sucessCount = 0;
    }

    public void SetWaterDifficulty(int speed, int requiredCount)
    {
        // something wrong
        moveSpeed = speed;
        requiredSucessCount = requiredCount;
    }

    private void OnEnable()
    {
        ResetWaterEvent();
        isMoving = true;
        canClick = true;
        startPosition = transform.position;
    }

}
