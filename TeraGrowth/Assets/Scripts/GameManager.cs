using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Intro State")]
    [SerializeField] private IntroManager introManager;

    [Header("Fade Screen")]
    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private ScreenFade screenfader;

    [Header("Game State")]
    [SerializeField] private GameObject[] scenes;

    [Header("Event State")]
    [SerializeField] private GameObject[] events;
    [SerializeField] private Shaker shakerEvents;

    private bool fadeTriggered = false;

    void Start()
    {

    }

    void Update()
    {
        // Spawn Jar
        if(introManager.IndexCall() == 1)
        {
            scenes[0].SetActive(true);
        }

        // Activate Fade, Play Morning Sound
        if (introManager.IndexCall() == 4)
        {
            if (!fadeTriggered)
            {
                fadeScreen.SetActive(true);
                screenfader.TriggerFadeToBlack();
                fadeTriggered = true;

                Invoke(nameof(ActivateEvent1), 0.1f);
            }
        }

        // Activate scene 2
        if (shakerEvents.EventComplete())
        {
            scenes[1].SetActive(true);
            events[0].SetActive(false);
            shakerEvents.ResetEvent();
        }
    }

    private void ActivateEvent1()
    {
        events[0].SetActive(true);
    }

}
