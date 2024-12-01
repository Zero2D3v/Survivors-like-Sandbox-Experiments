using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateEXPBar(float fillAmount)
    {
        characterOneEXPBar.fillAmount = fillAmount;
    }

    public void IncreaseEnemiesKilled()
    {
        enemiesKilled++;
        enemiesKilledText.text = enemiesKilled.ToString();
    }

    public void IncreaseTime(float gameTime)
    {
        minutes = Mathf.FloorToInt(gameTime / 60);
        seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        uiGameTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
