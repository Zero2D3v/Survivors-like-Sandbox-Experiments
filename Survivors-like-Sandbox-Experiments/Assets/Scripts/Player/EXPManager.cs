using UnityEngine;

/// <summary>
/// Handles all EXP related operations.
/// </summary>
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
    /// <summary>
    /// Calculates required EXp for next level.
    /// Exits if still in level 1 as modifier starts on level 2.
    /// </summary>
    /// <param name="level"></param>
    private void CalculateNextLevelXP(int level)
    {
        if (level <= 1) return;

        nextLevelXP *= nextLevelModifier;

        nextLevelXP = (int)nextLevelXP;
    }
    /// <summary>
    /// Resets the current EXP by minusing the next level EXP for resiting the bar.
    /// Increases the Level.
    /// Triggers CalculateNextLevelEXP()
    /// ** may be better as a unity event
    /// </summary>
    private void LevelUP()
    {
        //totalEXP += currentEXP;
        currentEXP -= nextLevelXP;
        level++;
        Debug.Log("Level UP!");
        CalculateNextLevelXP(level);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>returns the fill amount from 0 to 1 to be used in the UI based on the EXP stat values</returns>
    private float XPFillAmount()
    {
        if(currentEXP >= nextLevelXP)
        {
            LevelUP();
        }

        float xpFillAmount = currentEXP / nextLevelXP;

        return xpFillAmount;
    }
    /// <summary>
    /// Calls the UI manager to update the UI EXP bar
    /// </summary>
    private void UpdateExperienceUI()
    {
        uiManager.UpdateEXPBar(XPFillAmount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { IncreaseEXP(1f); Debug.Log("pressed E"); }
    }
    /// <summary>
    /// Increases EXP value and calls the UI to be updated.
    /// </summary>
    /// <param name="xpIncrease"></param>
    public void IncreaseEXP(float xpIncrease)
    {
        currentEXP += xpIncrease;
        totalEXP += xpIncrease;
        UpdateExperienceUI();
    }
}
