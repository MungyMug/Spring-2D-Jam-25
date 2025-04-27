using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Intro State")]
    [SerializeField] private IntroManager introManager;

    [Header("Fade Screen")]
    [SerializeField] private ScreenFade screenfader;

    [Header("Game State")]
    [SerializeField] private GameObject[] scenes;

    [Header("Event State")]
    [SerializeField] private GameObject[] events;

    [Header("UI State")]
    [SerializeField] private GameObject[] uiScene;

    [Header("Watering Can Event")]
    [SerializeField] private WateringCanMover[] wateringCan;

    [SerializeField] private Shaker[] shakerEvents;

    [SerializeField] private SnailEvent snailEvent;

    bool event1trigger = false;

    void Update()
    {
        // Spawn Jar
        if (introManager.IndexCall() == 1)
        {
            scenes[0].SetActive(true);
        }

        // Activate Fade, Play Morning Sound, Start Day 1
        if (introManager.IndexCall() == 4 && !event1trigger)
        {
            screenfader.TriggerFadeOut();
            Invoke(nameof(ActivateEvent1), 2f);
            event1trigger = true;
        }

        // Activate scene 1 outcomme Day 1 Complete
        if (shakerEvents[0].EventComplete())
        {
            scenes[1].SetActive(true);
            events[0].SetActive(false);

            // To reuse shaker
            shakerEvents[0].ResetEvent();

            ActivateEvent1Outcome();
        }

        // Activate scene 2 via button Start Day 2
        // public void ActivateScene2()

        // Right here is when the game end stage 2 water event
        if (wateringCan[0].EventComplete())
        {
            DisableEvent2();
            wateringCan[0].ResetWaterEvent();
            ActivateScene3UI();
        }

        if (wateringCan[1].EventComplete())
        {
            DisableEvent3();
            wateringCan[1].ResetWaterEvent();
            ActivateDay3EndUI();
        }

        // After the if() above, right here is where the stage 2 end screen is at
        // Button proceed to trigger fade, and then day 3 starts


        // Second SOil Event Check
        if (shakerEvents[1].EventComplete())
        {
            ActivateDay4EndUI();
            events[4].SetActive(false);

            // To reuse shaker
            shakerEvents[1].ResetEvent();
        }

        // Frog Event
        if (shakerEvents[2].EventComplete())
        {
            ActivateDay5Part1UI();
            ActivateDay5Part1Scene();
            events[5].SetActive(false);

            // To reuse shaker
            shakerEvents[2].ResetEvent();
        }

        if (snailEvent.SnailEventChecker())
        {
            ActivateDay5EndUI();
            snailEvent.ResetSnailEvent();
            events[6].SetActive(false);
        }

        if (shakerEvents[3].EventComplete())
        {
            ActivateDay6EndUI();
            events[7].SetActive(false);

            // To reuse shaker
            shakerEvents[3].ResetEvent();
        }

        if (wateringCan[2].EventComplete())
        {
            DisableEvent8();
            wateringCan[2].ResetWaterEvent();
            ActivateDay7EndUI();
        }

        // Day 8 Water Event
        if (wateringCan[3].EventComplete())
        {
            DisableEvent9();
            wateringCan[3].ResetWaterEvent();
            ActivateDay8Part1UI();
        }
        // Day 8 Dirt Event
        if (shakerEvents[4].EventComplete())
        {
            ActivateDay8EndUI();
            events[10].SetActive(false);

            // To reuse shaker
            shakerEvents[4].ResetEvent();
        }

        // Day 9 Water Event
        if (wateringCan[4].EventComplete())
        {
            DisableEvent11();
            wateringCan[4].ResetWaterEvent();
            ActivateDay9Part1UI();
        }

        // Day 9 Dirt Event
        if (shakerEvents[5].EventComplete())
        {
            ActivateDay9EndUI();
            events[12].SetActive(false);

            // To reuse shaker
            shakerEvents[5].ResetEvent();
        }
    }

    // Fade Event
    public void TriggerFade()
    {
        screenfader.TriggerFadeOut();
    }

    // Soil Event and Outcome
    private void ActivateEvent1()
    {
        events[0].SetActive(true);
    }

    public void ActivateEvent1Outcome()
    {
        events[1].SetActive(true);
    }

    // Water Event
    public void ActivateEvent2()
    {
        events[2].SetActive(true);
    }

    public void DisableEvent2()
    {
        events[2].SetActive(false);
    }

    // Trigger water event upong click again
    // But this time increase difficulty
    public void ActivateEvent3()
    {
        events[3].SetActive(true);
    }

    public void DisableEvent3()
    {
        events[3].SetActive(false);
    }

    // Scene2 Invoke
    public void ActivateScene2Invoke()
    {
        // Disable previous event
        events[1].SetActive(false);

        // Start Day 2 Scene change and UI
        scenes[2].SetActive(true);
        uiScene[0].SetActive(true);
    }

    public void InvokeScene2()
    {
        Invoke(nameof(ActivateScene2Invoke), 2f);
    }

    public void DisableScene2UI()
    {
        uiScene[0].SetActive(false);
    }

    public void DisableScene2()
    {
        scenes[2].SetActive(false);
    }

    // Scene 3
    public void ActivateScene3UI()
    {
        uiScene[1].SetActive(true);
    }

    public void DisableScene3UI()
    {
        uiScene[1].SetActive(false);
    }

    // Day 3 starts here
    // First is rendering of the updated jar
    public void InvokeDay3Scene()
    {
        Invoke(nameof(ActivateScene3), 2f);
    }
    public void ActivateScene3()
    {
        scenes[3].SetActive(true);
    }
    public void DisableScene3()
    {
        scenes[3].SetActive(false);
    }

    // Disable Day 3 UI
    public void DisableDay3UI()
    {
        uiScene[2].SetActive(false);
    }

    // Activate Day 3 UI
    public void InvokeDay3UI()
    {
        Invoke(nameof(ActivateDay3UI), 2f);
    }
    private void ActivateDay3UI()
    {
        uiScene[2].SetActive(true);
    }

    public void ActivateDay3EndUI()
    {
        uiScene[3].SetActive(true);
    }

    public void DisableDay3EndUI()
    {
        uiScene[3].SetActive(false);
    }

    // Activate Day 4 Scene
    public void InvokeDay4Scene()
    {
        Invoke(nameof(ActivateDay4Scene), 2f);
    }
    public void ActivateDay4Scene()
    {
        scenes[4].SetActive(true);
    }

    public void DisableDay4Scene()
    {
        scenes[4].SetActive(false);
    }

    public void InvokeDay4UI()
    {
        Invoke(nameof(ActivateDay4UI), 2f);
    }

    public void ActivateDay4UI()
    {
        uiScene[4].SetActive(true);
    }

    public void DisableDay4UI()
    {
        uiScene[4].SetActive(false);
    }

    public void ActivateDay4EndUI()
    {
        uiScene[5].SetActive(true);
    }

    public void DisableDay4EndUI()
    {
        uiScene[5].SetActive(false);
    }

    public void ActivateEvent4()
    {
        events[4].SetActive(true);
    }

    // Activate Day 5 Scene
    public void InvokeDay5Scene()
    {
        Invoke(nameof(ActivateDay5Scene), 2f);
    }
    public void ActivateDay5Scene()
    {
        scenes[5].SetActive(true);
    }

    public void DisableDay5Scene()
    {
        scenes[5].SetActive(false);
    }

    public void InvokeDay5UI()
    {
        Invoke(nameof(ActivateDay5UI), 2f);
    }

    public void ActivateDay5UI()
    {
        uiScene[6].SetActive(true);
    }

    public void DisableDay5UI()
    {
        uiScene[6].SetActive(false);
    }

    public void ActivateDay5Part1Scene()
    {
        scenes[6].SetActive(true);
    }

    public void DisableDay5Part1Scene()
    {
        scenes[6].SetActive(false);
    }

    public void ActivateDay5Part1UI()
    {
        uiScene[7].SetActive(true);
    }

    public void DisableDay5Part1UI()
    {
        uiScene[7].SetActive(false);
    }

    public void ActivateEvent5()
    {
        events[5].SetActive(true);
    }

    // Snail Event
    public void ActivateEvent6()
    {
        events[6].SetActive(true);
    }

    public void ActivateDay5EndUI()
    {
        uiScene[8].SetActive(true);
    }

    public void DisableDay5EndUI()
    {
        uiScene[8].SetActive(false);
    }

    // Activate Day 6 Scene
    public void InvokeDay6Scene()
    {
        Invoke(nameof(ActivateDay6Scene), 2f);
    }
    public void ActivateDay6Scene()
    {
        scenes[7].SetActive(true);
    }

    public void DisableDay6Scene()
    {
        scenes[7].SetActive(false);
    }

    public void InvokeDay6UI()
    {
        Invoke(nameof(ActivateDay6UI), 2f);
    }

    public void ActivateDay6UI()
    {
        uiScene[9].SetActive(true);
    }

    public void DisableDay6UI()
    {
        uiScene[9].SetActive(false);
    }

    public void ActivateDay6EndUI()
    {
        uiScene[10].SetActive(true);
    }

    public void DisableDay6EndUI()
    {
        uiScene[10].SetActive(false);
    }

    public void ActivateEvent7()
    {
        events[7].SetActive(true);
    }

    // Activate Day 7 Scene
    public void InvokeDay7Scene()
    {
        Invoke(nameof(ActivateDay7Scene), 2f);
    }
    public void ActivateDay7Scene()
    {
        scenes[8].SetActive(true);
    }

    public void DisableDay7Scene()
    {
        scenes[8].SetActive(false);
    }

    public void InvokeDay7UI()
    {
        Invoke(nameof(ActivateDay7UI), 2f);
    }

    public void ActivateDay7UI()
    {
        uiScene[11].SetActive(true);
    }

    public void DisableDay7UI()
    {
        uiScene[11].SetActive(false);
    }

    public void ActivateDay7EndUI()
    {
        uiScene[12].SetActive(true);
    }

    public void DisableDay7EndUI()
    {
        uiScene[12].SetActive(false);
    }

    public void ActivateEvent8()
    {
        events[8].SetActive(true);
    }

    public void DisableEvent8()
    {
        events[8].SetActive(false);
    }
    // ====================================================== Day 8 ===================================================
    // Activate Day 8 Scene
    public void InvokeDay8Scene()
    {
        Invoke(nameof(ActivateDay8Scene), 2f);
    }
    public void ActivateDay8Scene()
    {
        scenes[9].SetActive(true);
    }

    public void DisableDay8Scene()
    {
        scenes[9].SetActive(false);
    }

    public void InvokeDay8UI()
    {
        Invoke(nameof(ActivateDay8UI), 2f);
    }

    public void ActivateDay8UI()
    {
        uiScene[13].SetActive(true);
    }

    public void DisableDay8UI()
    {
        uiScene[13].SetActive(false);
    }
    //Day 8 part 1
    public void ActivateDay8Part1UI()
    {
        uiScene[14].SetActive(true);
    }
    public void DisableDay8Part1UI()
    {
        uiScene[14].SetActive(false);
    }

    //Day 8 end
    public void ActivateDay8EndUI()
    {
        uiScene[15].SetActive(true);
    }

    public void DisableDay8EndUI()
    {
        uiScene[15].SetActive(false);
    }

    // Day 8 water event
    public void ActivateEvent9()
    {
        events[9].SetActive(true);
    }

    public void DisableEvent9()
    {
        events[9].SetActive(false);
    }

    // Day 8 Soil Event
    public void ActivateEvent10()
    {
        events[10].SetActive(true);
    }

    // ====================================================== Day 9 ===================================================
    public void InvokeDay9Scene()
    {
        Invoke(nameof(ActivateDay9Scene), 2f);
    }
    public void ActivateDay9Scene()
    {
        scenes[10].SetActive(true);
    }

    public void DisableDay9Scene()
    {
        scenes[10].SetActive(false);
    }

    public void InvokeDay9UI()
    {
        Invoke(nameof(ActivateDay9UI), 2f);
    }
    public void ActivateDay9UI()
    {
        uiScene[16].SetActive(true);
    }

    public void DisableDay9UI()
    {
        uiScene[16].SetActive(false);
    }
    //Day 9 part 1
    public void ActivateDay9Part1UI()
    {
        uiScene[17].SetActive(true);
    }
    public void DisableDay9Part1UI()
    {
        uiScene[17].SetActive(false);
    }

    //Day 9 end
    public void ActivateDay9EndUI()
    {
        uiScene[18].SetActive(true);
    }

    public void DisableDay9EndUI()
    {
        uiScene[18].SetActive(false);
    }

    // Day 9 water event
    public void ActivateEvent11()
    {
        events[11].SetActive(true);
    }

    public void DisableEvent11()
    {
        events[11].SetActive(false);
    }

    // Day 9 Soil Event
    public void ActivateEvent12()
    {
        events[12].SetActive(true);
    }

    // ====================================================== Day 10 ===================================================
    public void InvokeDay10Scene()
    {
        Invoke(nameof(ActivateDay10Scene), 2f);
    }
    public void ActivateDay10Scene()
    {
        scenes[11].SetActive(true);
    }

    public void DisableDay10Scene()
    {
        scenes[11].SetActive(false);
    }

    public void InvokeDay10UI()
    {
        Invoke(nameof(ActivateDay10UI), 2f);
    }
    public void ActivateDay10UI()
    {
        uiScene[19].SetActive(true);
    }

    public void DisableDay10UI()
    {
        uiScene[19].SetActive(false);
    }

    public void ActivateDay10UIP2()
    {
        uiScene[20].SetActive(true);
    }

    public void DisableDay10UIP2()
    {
        uiScene[20].SetActive(true);
    }
}
