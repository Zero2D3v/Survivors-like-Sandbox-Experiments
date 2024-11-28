using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [Header("Hero Panels")]
    [SerializeField] GameObject titleScreenPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject mainMenuFirstButton;

    [Header("FX Panel/Variables")]
    [SerializeField] Image fadePanel;
    [SerializeField] GameObject pressAnyButtonObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressAnyButtonObj.SetActive(false);

        DisablePanel(mainMenuPanel);
    }

    private void DisableFadePanel()
    {
        EnablePressAnyButtonOBJ();
        fadePanel.enabled = false;
    }
    private void EnablePressAnyButtonOBJ()
    {
        pressAnyButtonObj.SetActive(true);
    }

    private void EnablePanel(GameObject activePanel)
    {
        
        activePanel.SetActive(true);

        //if (activePanel == mainMenuPanel) { EventSystem.current.SetSelectedGameObject(mainMenuFirstButton); Debug.Log(EventSystem.current.currentSelectedGameObject); }
    }
    private void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        AnyButtonPressed();
    }

    private void AnyButtonPressed()
    {
        if (!pressAnyButtonObj) return;

        if (Input.anyKeyDown)
        {
            pressAnyButtonObj.SetActive(false);
            DisablePanel(titleScreenPanel);
            EnablePanel(mainMenuPanel);
            EventSystem.current.firstSelectedGameObject = mainMenuFirstButton;
        }
    }
}
