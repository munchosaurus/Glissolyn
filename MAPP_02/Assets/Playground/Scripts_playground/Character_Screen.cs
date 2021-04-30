using UnityEngine;
using UnityEngine.UI;

public class Character_Screen : MonoBehaviour
{
    private readonly int INCREASE_BY_ONE = 1;

    [SerializeField] Text strengthValue;
    [SerializeField] Text agilityValue;
    [SerializeField] Text intelligenceValue;
    [SerializeField] Text statPointsValue;
    [SerializeField] Button strengthIncreaseButton;
    [SerializeField] Button agilityIncreaseButton;
    [SerializeField] Button intelligenceIncreaseButton;

    private void ShowButtons(bool toggle)
    {
        strengthIncreaseButton.gameObject.SetActive(toggle);
        agilityIncreaseButton.gameObject.SetActive(toggle);
        intelligenceIncreaseButton.gameObject.SetActive(toggle);
    }

    private void UpdateValues()
    {
        strengthValue.text = Game_Controller.GetPlayerInfo().GetBase().GetStrength().ToString();
        agilityValue.text = Game_Controller.GetPlayerInfo().GetBase().GetAgility().ToString();
        intelligenceValue.text = Game_Controller.GetPlayerInfo().GetBase().GetIntelligence().ToString();
        statPointsValue.text = Game_Controller.GetPlayerInfo().GetStatPoints().ToString();

        if(Game_Controller.GetPlayerInfo().GetStatPoints() > 0)
        {
            ShowButtons(true);
        }
        else
        {
            ShowButtons(false);
        }
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
