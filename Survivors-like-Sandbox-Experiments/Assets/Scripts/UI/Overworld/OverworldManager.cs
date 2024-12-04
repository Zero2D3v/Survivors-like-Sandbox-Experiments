using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Responsible for managing all operations and interactions in navigating the Overworld scene.
/// </summary>
public class OverworldManager : MonoBehaviour
{
    [Header("Overworld Navigation Panels")]
    [SerializeField] GameObject mapPanel;
    [SerializeField] GameObject charactersPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject statsPanel;

    [Header("OverWorld Navigation Buttons")]
    [SerializeField] GameObject mapButton;
    [SerializeField] GameObject charactersButton;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject statsButton;

    [Header("Character Sub Panels")]
    [SerializeField] GameObject partyPanel;
    [SerializeField] GameObject characterSpecificPanel;

    private List<GameObject> navPanelList;
    private List<GameObject> characterSubPanelList;
    private List<Button> baseOverworldButtons;

    private List<GameObject> activeSubPanelList;
    private GameObject activeBasePanel;
    private GameObject activePanel;
    private GameObject prevPanel;

    private void Start()
    {
        CreateButtonLists();
        CreateBasePanelList();
        CreateSubPanelLists();
        DisableAllBasePanels();
    }
    /// <summary>
    /// Creates a list of  the 4 base panels in the Overworld
    /// </summary>
    private void CreateBasePanelList()
    {
        navPanelList = new List<GameObject>(4);
        navPanelList.Add(mapPanel);
        navPanelList.Add(charactersPanel);
        navPanelList.Add(shopPanel);
        navPanelList.Add(statsPanel);
    }
    /// <summary>
    /// Creates a list of sub panels for each panel --> needs work didn't end up using as base panel is screen1 and sub panel is screen 2 as opposed to one base and 2 sub panels.
    /// </summary>
    private void CreateSubPanelLists()
    {
        characterSubPanelList = new List<GameObject>();
        //characterSubPanelList.Add(partyPanel);
        characterSubPanelList.Add(characterSpecificPanel);
    }
    /// <summary>
    /// Creates a reference to each button of a certain level to allow for easy access and disabling input on deeper menu levels.
    /// </summary>
    private void CreateButtonLists()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("baseOverworldButtons");

        baseOverworldButtons = new List<Button>(buttons.Length);

        foreach (GameObject button in buttons) baseOverworldButtons.Add(button.GetComponent<Button>());
    }
    /// <summary>
    /// Disables all base panels and removes activeBasePanel ref
    /// </summary>
    private void DisableAllBasePanels()
    {
        foreach (GameObject obj in navPanelList)
        {
            obj.SetActive(false);
            activeBasePanel = null;
        }
    }
    //private void DisableAllSubPanels()
    //{
    //    if (activeSubPanelList == null) return;
    //
    //    foreach (GameObject obj in activeSubPanelList)
    //    {
    //        obj.SetActive(false);
    //        activeSubPanel = null;
    //    }
    //
    //}

    /// <summary>
    /// Dasable all base panels from base panel list. Enable desired base panel. Call SuspendButton() operation to enable next button control scheme.
    /// Updates references - activeBasePanel - activePanel
    /// Suspend base buttons.
    /// </summary>
    /// <param name="panel"></param>
    public void EnableBasePanel(GameObject panel)
    {
        foreach(GameObject obj in navPanelList)
        {
            obj.SetActive(false);
        }

        SuspendButtons(baseOverworldButtons);

        panel.SetActive(true);
        activeBasePanel = panel;
        activePanel = activeBasePanel;
    }
    /// <summary>
    /// Enables any panel.
    /// Updates activePanel.
    /// </summary>
    /// <param name="nextPanel"></param>
    public void EnablePanel(GameObject nextPanel)
    {
        //prevPanel = activePanel;
        

        nextPanel.SetActive(true);
        
        activePanel = nextPanel;
        //prevPanel.SetActive(false);
    }
    /// <summary>
    /// Disables panel and activates previous panel and removes previous reference. **this system needs refactoring.
    /// </summary>
    public void DisablePanel()
    {
        activePanel.SetActive(false);
        prevPanel.SetActive(true);
        prevPanel = null;
        
    }
    /// <summary>
    /// Disables panel and records disabled panel.
    /// </summary>
    /// <param name="panel"></param>
    public void JustDisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        prevPanel = panel;
    }

    /// <summary>
    /// Sets Sub Panel GameObject from Sub panel List to active. Takes in 'List<GameObject>' and 'Gameobject'.
    /// </summary>
    /// <param name="panelList"></param>
    /// <param name="panel"></param>
    //private void EnableSubPanel(List<GameObject> panelList, GameObject panel)
    //{
    //    foreach (GameObject obj in panelList)
    //    {
    //        obj.SetActive(false);
    //    }
    //
    //    panel.SetActive(true);
    //
    //    activeSubPanelList = panelList;
    //    activeSubPanel = panel;
    //}

    /// <summary>
    /// Handles 'Back' operation in menus.
    /// Dependent on how deep into menus dependent on if prevPanel reference is stored **needs scale refactoring but like the idea of one function for back
    /// </summary>
    public void Back()
    {
        if (!activeBasePanel) { return; }

        if (prevPanel) { DisablePanel(); return; }
        else if (!prevPanel) { DisableAllBasePanels(); EnableButtons(baseOverworldButtons); SetActiveButton(charactersButton); }
    }

    //public void EnableCharacterSubPanel(GameObject subPanel)
    //{
    //    EnableSubPanel(characterSubPanelList, subPanel);
    //}
    /// <summary>
    /// Sets active button needed for controller input.
    /// Directly sets the button to be first as 'FirstSelectedGameObject' only works at start of scene.
    /// </summary>
    /// <param name="button"></param>
    public void SetActiveButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
    /// <summary>
    /// Suspends all button operations in list.
    /// </summary>
    /// <param name="buttonList"></param>
    public void SuspendButtons(List<Button> buttonList)
    {
        foreach (var item in buttonList)
        {
            item.interactable = false;
        }
    }
    /// <summary>
    /// Resumes button operations in list
    /// </summary>
    /// <param name="buttonList"></param>
    public void EnableButtons(List<Button> buttonList)
    {
        foreach (var item in buttonList)
        {
            item.interactable = true;
        }
    }

    //obselete as EnablePanel handles disabling all other panels
    //public void DisablePanel(GameObject panel)
    //{
    //    panel.SetActive(false);
    //}

    //obsolete as can declare in EnablePanel
    //private void CheckActivePanel()
    //{
    //    if(!activePanel) { Debug.Log("No activePanel assigned!"); return; }
    //
    //    
    //}

    //to suspend button operations can either use canvas groups or create lists for each active panel? --> maybe cam use a serialised public class list so all relevant info would be on same ref.
    //or assign with tag eg- "overworldBaseButtons"

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Back(); }
    }
}
