using UnityEngine;

public class SnailEvent : MonoBehaviour
{
    [SerializeField] private int snailCount = 0;
    [SerializeField] private int maxSnailCount = 5;

    private bool eventcompleted = false;

    AudioManager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(snailCount >= maxSnailCount)
        {
            eventcompleted = true;
        }
    }

    public bool SnailEventChecker()
    {
        if (eventcompleted)
        {
            return true;
        }
        return false;
    }

    public void IncreaseSnailCount()
    {
        audiomanager.PlaySFX(audiomanager.slug);
        snailCount++;
    }

    public void ResetSnailEvent()
    {
        snailCount = 0;
        eventcompleted = false;
    }
}
