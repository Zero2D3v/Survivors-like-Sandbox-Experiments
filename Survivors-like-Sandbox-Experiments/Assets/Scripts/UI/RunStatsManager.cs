using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// First attempt at a UnityEvents Manager.
/// Turned into TimeTcker Script.
/// </summary>
public class RunStatsManager : MonoBehaviour
{
    [Header("Tracked Stats")]
    [SerializeField] int enemiesKilled;
    [SerializeField] int expGained;
    [SerializeField] float timePlayed;

    public UnityEvent TimeTicked;
    private float timeTicker;
    //private UIManager uiManager;

    private void Start()
    {
        enemiesKilled = 0;
        expGained = 0;
        timePlayed = 0;
        ResetTicker();

        UIManager uiManager = GameObject.FindGameObjectWithTag("uiManager").GetComponent<UIManager>();
        TimeTicked.AddListener(() => uiManager.IncreaseTime(timePlayed));

        
    }

    public void IncreaseTime()
    {
        timePlayed += Time.deltaTime;
        //uiManager.gameTime = timePlayed;
    }

    private void Update()
    {
        timeTicker += Time.deltaTime;
        IncreaseTime();

        if(timeTicker >= 0.1f)
        {
            TimeTicked.Invoke();
            ResetTicker();
        }
    }
    private void ResetTicker()
    {
        timeTicker = 0;
    }
}
