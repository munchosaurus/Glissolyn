using UnityEngine;
using UnityEngine.UI;

public class Character_Screen : MonoBehaviour
{
    private readonly int INCREASE_BY_ONE = 1;

    [SerializeField] Image playerImage;
    [SerializeField] Text playerName;
    [SerializeField] Text strengthValue;
    [SerializeField] Text agilityValue;
    [SerializeField] Text intelligenceValue;
    [SerializeField] Text statPointsValue;
    [SerializeField] Button strengthIncreaseButton;
    [SerializeField] Button agilityIncreaseButton;
    [SerializeField] Button intelligenceIncreaseButton;
    [SerializeField] Slider healthBar;
    [SerializeField] Text healthBarValue;
    [SerializeField] Slider experienceBar;
    [SerializeField] Text experienceBarValue;

    private void ShowButtons(bool toggle)
    {
        strengthIncreaseButton.gameObject.SetActive(toggle);
        agilityIncreaseButton.gameObject.SetActive(toggle);
        intelligenceIncreaseButton.gameObject.SetActive(toggle);
    }

    private void UpdateValues()
    {
        Player_Info thePlayerInfo = Game_Controller.GetPlayerInfo();
        strengthValue.text = thePlayerInfo.GetBase().GetStrength().ToString();
        agilityValue.text = thePlayerInfo.GetBase().GetAgility().ToString();
        intelligenceValue.text = thePlayerInfo.GetBase().GetIntelligence().ToString();
        statPointsValue.text = thePlayerInfo.GetStatPoints().ToString();
        healthBar.value = thePlayerInfo.GetHealth()/thePlayerInfo.GetBase().GetMaxHP();
        healthBarValue.text = thePlayerInfo.GetHealth().ToString() + "/" + thePlayerInfo.GetBase().GetMaxHP().ToString();
        experienceBar.value = thePlayerInfo.GetExperience()/thePlayerInfo.GetNextLevelExperience();
        experienceBarValue.text = thePlayerInfo.GetExperience().ToString() + "/" + thePlayerInfo.GetNextLevelExperience().ToString();

        if (Game_Controller.GetPlayerInfo().GetStatPoints() > 0)
        {
            ShowButtons(true);
        }
        else
        {
            ShowButtons(false);
        }
    }

    public void Initialize()
    {
        playerName.text = Game_Controller.GetPlayerInfo().GetName();
        playerImage.sprite = Game_Controller.GetPlayerInfo().GetPlayerSprite();
    }

    public void IncreaseStrength()
    {
        Game_Controller.GetPlayerInfo().GetBase().ModifyStrength(INCREASE_BY_ONE);
        Game_Controller.GetPlayerInfo().SpendStatPoint();
        UpdateValues();
    }

    public void IncreaseAgility()
    {
        Game_Controller.GetPlayerInfo().GetBase().ModifyAgility(INCREASE_BY_ONE);
        Game_Controller.GetPlayerInfo().SpendStatPoint();
        UpdateValues();
    }

    public void IncreaseIntelligence()
    {
        Game_Controller.GetPlayerInfo().GetBase().ModifyIntelligence(INCREASE_BY_ONE);
        Game_Controller.GetPlayerInfo().SpendStatPoint();
        UpdateValues();
    }

    public void Toggle()
    {
        UpdateValues();
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }
}
