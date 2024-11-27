using UnityEngine;

public class EXPManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] float nextLevelModifier = 1.5f;
    [SerializeField] float nextLevelXP = 5f;

    float totalEXP;
    float currentEXP;
    
    int level;

    private void Start()
    {
        level = playerStats.level;
        currentEXP = playerStats.exp;
        nextLevelXP = 5f;
        totalEXP = currentEXP;

        CalculateNextLevelXP(level);
    }

    private void CalculateNextLevelXP(int level)
    {
        if (level <= 1) return;

        nextLevelXP *= 1.5f;

        nextLevelXP = (int)nextLevelXP;
    }
    private void LevelUP()
    {
        //totalEXP += currentEXP;
        currentEXP -= nextLevelXP;
        level++;
        Debug.Log("Level UP!");
        CalculateNextLevelXP(level);
    }

    private float XPFillAmount()
    {
        if(currentEXP >= nextLevelXP)
        {
            LevelUP();
        }

        float xpFillAmount = currentEXP / nextLevelXP;

        return xpFillAmount;
    }

    private void UpdateExperienceUI()
    {
        uiManager.UpdateEXPBar(XPFillAmount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { IncreaseEXP(1f); Debug.Log("pressed E"); }
    }

    private void IncreaseEXP(float xpIncrease)
    {
        currentEXP += xpIncrease;
        totalEXP += xpIncrease;
        UpdateExperienceUI();
    }
}
