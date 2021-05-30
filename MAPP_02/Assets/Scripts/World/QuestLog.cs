using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private Button questButtonPrefab;
    [SerializeField] private GameObject newQuestIcon;

    private Dictionary<int, Quest> activeQuests = new Dictionary<int, Quest>();
    private QuestButton currentOpenQuestButton;

    /*
     * Adds a Quest-object to the Dictionary activeQuests with the quest ID as key and the Quest object as value.
     * Parameters: quest - A Quest-object.
     */
    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest.GetQuestID(), quest);
        Button theQuestButton = Instantiate(questButtonPrefab, transform.Find("Quest List Area").transform.Find("Viewport").transform.Find("Content")); // Create a new Quest Button prefeb as a child to the "Content"-GameObject under the "Quest List Area"-GameObject.
        theQuestButton.GetComponent<QuestButton>().Initialize(quest); // Add the information from the Quest-object to the "Quest Button"-GameObject.
        if(currentOpenQuestButton == null)
        {
            currentOpenQuestButton = quest.GetQuestButton();
        }
        Game_Controller.UpdateWorldToQuestClearState(quest.GetQuestPickUpState());
        ShowNewQuestIcon();
    }

    public void RemoveQuest(int id)
    {
        if (activeQuests.ContainsKey(id))
        {
            if(currentOpenQuestButton == activeQuests[id].GetQuestButton())
            {
                gameObject.transform.Find("Quest Text Area").GetComponentInChildren<Text>().text = "";
                currentOpenQuestButton = null;
            }
            Destroy(activeQuests[id].GetQuestButton().gameObject);
            activeQuests.Remove(id);
            
        }
    }

    public bool HasQuest(Quest quest)
    {
        return activeQuests.ContainsKey(quest.GetQuestID());
    }

    public void UpdateKillQuestsWithEnemyType(CharacterBase _base)
    { 
        foreach(KeyValuePair<int, Quest> entry in activeQuests)
        {
            if(entry.Value.GetQuestType() == QuestType.KILL_QUEST)
            {
                Quest_KillQuest q = entry.Value as Quest_KillQuest;
                if(q.GetEnemyToKill() == _base)
                {
                    q.UpdateQuest();
                }
            }
        }
    }

    public void UpdateQuestAfterInteraction(string name)
    {
        foreach (KeyValuePair<int, Quest> entry in activeQuests)
        {
            if (entry.Value.GetQuestType() == QuestType.INTERACTION_QUEST)
            {
                Quest_InteractionQuest q = entry.Value as Quest_InteractionQuest;
                q.CheckInteraction(name);
                
            }
        }
    }

    public void SetCurrentOpenQuestButton(QuestButton questButton)
    {
        currentOpenQuestButton = questButton;
    }

    public void Toggle()
    {
        if (currentOpenQuestButton != null)
        {
            currentOpenQuestButton.OnClick();
        }
        newQuestIcon.SetActive(false);
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Game_Controller.SetPause(gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }

    public void ShowNewQuestIcon()
    {
        newQuestIcon.SetActive(true);
    }
}
