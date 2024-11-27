using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    [Header("Overworld Navigation Panels")]
    [SerializeField] GameObject mapPanel;
    [SerializeField] GameObject charactersPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject statsPanel;

    private List<GameObject> navPanelList;
    private GameObject activePanel;

    private void Start()
    {
        CreatePanelList();
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
    private void DisableAllPanels()
    {
        foreach (GameObject obj in navPanelList)
        {
            obj.SetActive(false);
            activePanel = null;
        }
    }
    public void EnablePanel(GameObject panel)
    {
        foreach(GameObject obj in navPanelList)
        {
            obj.SetActive(false);
        }

        panel.SetActive(true);
        activePanel = panel;
    }
    public void Back()
    {
        if (!activePanel) { return; }

        if (activePanel) DisableAllPanels();
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
