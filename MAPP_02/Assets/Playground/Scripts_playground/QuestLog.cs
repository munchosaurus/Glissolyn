using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private Button questButtonPrefab;

    private Dictionary<int, Quest> activeQuests = new Dictionary<int, Quest>();

    /*
     * Adds a Quest-object to the Dictionary activeQuests with the quest ID as key and the Quest object as value.
     * Parameters: quest - A Quest-object.
     */
    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest.GetQuestID(), quest);
        Button theQuestButton = Instantiate(questButtonPrefab, transform.Find("Quest List Area").transform.Find("Viewport").transform.Find("Content")); // Create a new Quest Button prefeb as a child to the "Content"-GameObject under the "Quest List Area"-GameObject.
        theQuestButton.GetComponent<QuestButton>().Initialize(quest.GetQuestTitle(), quest.GetQuestText(), quest.GetQuestID()); // Add the information from the Quest-object to the "Quest Button"-GameObject.
    }

    public void RemoveQuest(int id)
    {
        if (activeQuests.ContainsKey(id))
        {
            Destroy(gameObject.transform.Find(activeQuests[id].GetQuestTitle()));
            activeQuests.Remove(id);
        }
    }

    public bool HasQuest(int id)
    {
        return activeQuests.ContainsKey(id);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        Game_Controller.TogglePause(gameObject.activeInHierarchy);
    }

    public bool IsOpen()
    {
        return gameObject.activeInHierarchy;
    }
}
