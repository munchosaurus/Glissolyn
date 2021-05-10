using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private Button questButtonPrefab;

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
    }

    public void RemoveQuest(int id)
    {
        if (activeQuests.ContainsKey(id))
        {
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
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Game_Controller.SetPause(gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }
}