using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a temporary script to test the Quest Log.
public class GetAQuest : MonoBehaviour
{
    [SerializeField] GameObject questLog;

    private string questTitle = "A quest";
    private string questText = "This is a quest";
    private bool hasEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!hasEntered)
            {
                questLog.GetComponent<QuestLog>().AddQuest(new TestQuest(questTitle, questText));
                hasEntered = true;
            }

            questLog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            questLog.SetActive(false);
        }
    }
}
