using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        CreatePanelList();
        CreateSubPanelLists();
        DisableAllPanels();
    }
    private void CreatePanelList()
    {
        navPanelList = new List<GameObject>(4);
        navPanelList.Add(mapPanel);
        navPanelList.Add(charactersPanel);
        navPanelList.Add(shopPanel);
        navPanelList.Add(statsPanel);
    }
    private void CreateSubPanelLists()
    {
        characterSubPanelList = new List<GameObject>();
        //characterSubPanelList.Add(partyPanel);
        characterSubPanelList.Add(characterSpecificPanel);
    }
    private void CreateButtonLists()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("baseOverworldButtons");

        baseOverworldButtons = new List<Button>(buttons.Length);

        foreach (GameObject button in buttons) baseOverworldButtons.Add(button.GetComponent<Button>());
    }

    private void DisableAllPanels()
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

    public void EnablePanel(GameObject nextPanel)
    {
        //prevPanel = activePanel;
        

        nextPanel.SetActive(true);
        
        activePanel = nextPanel;
        //prevPanel.SetActive(false);
    }
    public void DisablePanel()
    {
        activePanel.SetActive(false);
        prevPanel.SetActive(true);
        prevPanel = null;
        
    }
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
    public void Back()
    {
        if (!activeBasePanel) { return; }

        if (prevPanel) { DisablePanel(); return; }
        else if (!prevPanel) { DisableAllPanels(); EnableButtons(baseOverworldButtons); SetActiveButton(charactersButton); }
    }
    //public void EnableCharacterSubPanel(GameObject subPanel)
    //{
    //    EnableSubPanel(characterSubPanelList, subPanel);
    //}
    public void SetActiveButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }

    public void SuspendButtons(List<Button> buttonList)
    {
        foreach (var item in buttonList)
        {
            item.interactable = false;
        }
    }
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
