using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Text Components")]
    [SerializeField] TextMeshProUGUI uiGameTimer;
    [SerializeField] TextMeshProUGUI areaText;
    [SerializeField] TextMeshProUGUI stageText;

    [Header("EXP Components")]
    [SerializeField] Image characterOneEXPBar;

    private void Start()
    {
        characterOneEXPBar.fillAmount = 0;

    }

    public void UpdateEXPBar(float fillAmount)
    {
        characterOneEXPBar.fillAmount = fillAmount;
    }

    
}
