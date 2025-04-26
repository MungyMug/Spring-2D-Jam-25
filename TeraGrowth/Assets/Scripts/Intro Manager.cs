using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [Header("Intro Screens")]
    [SerializeField] private GameObject[] introPanels;

    [SerializeField] private Button nextButton;

    private int currentIntroIndex = 0;

    private void Start()
    {
        ShowCurrentIntro();
    }

    public void OnButtonClicked()
    {
        currentIntroIndex++;

        if (currentIntroIndex < introPanels.Length)
        {
            ShowCurrentIntro();
        }
        else
        {
            gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }

    private void ShowCurrentIntro()
    {
        foreach (var panel in introPanels)
        {
            panel.SetActive(false);
        }

        if (currentIntroIndex < introPanels.Length)
        {
            introPanels[currentIntroIndex].SetActive(true);
        }
    }
}
