using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private Button questButtonPrefab;

    private Dictionary<int, Quest> activeQuests = new Dictionary<int, Quest>();

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest.GetQuestID(), quest);
        Button theQuestButton = Instantiate(questButtonPrefab, transform.Find("Quest List Area").transform.Find("Viewport").transform.Find("Content"));
        theQuestButton.GetComponent<QuestButton>().Initialize(quest.GetQuestTitle(), quest.GetQuestText(), quest.GetQuestID());
    }
}
