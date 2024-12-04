using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles all UI operations, specifically handles the abstracted control of the UI elements.
/// Fed fromm other scripts so all this script is responsible for is controlling images and text etc.
/// </summary>
public class UIManager : MonoBehaviour
{

    [Header("Text Components")]
    [SerializeField] TextMeshProUGUI uiGameTimer;
    [SerializeField] TextMeshProUGUI areaText;
    [SerializeField] TextMeshProUGUI stageText;
    //Objective 1 Variables --> think would be better as a bundle somehow
    [Header("Objective 1")]
    [SerializeField] TextMeshProUGUI objective1Header;
    [SerializeField] TextMeshProUGUI objective1ProgressText;
    //Objective 2 Variables
    [Header("Objective 2")]
    [SerializeField] TextMeshProUGUI objective2Header;
    [SerializeField] TextMeshProUGUI objective2ProgressText;
    //UnityEvent Tests
    [Header("UnityEventTest")]
    [SerializeField] TextMeshProUGUI enemiesKilledText;
    private int enemiesKilled;
    //public float gameTime;
    private int minutes;
    private int seconds;

    [Header("EXP Components")]
    [SerializeField] Image characterOneEXPBar;

    private void Start()
    {
        characterOneEXPBar.fillAmount = 0;
        enemiesKilled = 0;
        enemiesKilledText.text = enemiesKilled.ToString();
    }
    /// <summary>
    /// Updates UI EXP bar to new fill amount between 0 and 1.
    /// </summary>
    /// <param name="fillAmount"></param>
    public void UpdateEXPBar(float fillAmount)
    {
        characterOneEXPBar.fillAmount = fillAmount;
    }

    public void IncreaseEnemiesKilled()
    {
        enemiesKilled++;
        enemiesKilledText.text = enemiesKilled.ToString();
    }
    /// <summary>
    /// Converts passed in gametime to a digital format of minutes and seconds using 'string.Format' and updates the text element for the UI Game Timer.
    /// Called through unity event every 0.1f seconds for less draw calls but unnoticable difference in visual performance
    /// **invokerepeating could also be used potentially
    /// </summary>
    /// <param name="gameTime"></param>
    public void IncreaseTime(float gameTime)
    {
        minutes = Mathf.FloorToInt(gameTime / 60);
        seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        uiGameTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
