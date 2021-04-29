using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Create new Kill Quest")]
public class Quest_KillQuest : Quest
{
    [SerializeField] private int amountToKill;
    [SerializeField] private CharacterBase enemyToKill;
    private string objectiveText;
    private int killed;

    override
    public void Init()
    {
        killed = 0;
        objectiveText = "";
        base.Init();
    }

    override
    public void UpdateQuest()
    {
        if(killed < amountToKill)
        {
            killed++;
        }
        questButton.UpdateQuestText(GetQuestText());
    }

    override
    protected void BuildQuestText()
    {
        objectiveText = enemyToKill.GetName() + ": " + killed + "/" + amountToKill;
        questText = questDescription + "\n\n" + objectiveText;
    }
    
    override
    public bool CompleteQuest()
    {
        if(killed == amountToKill)
        {
            isCompleted = true;
            Game_Controller.GetQuestLog().RemoveQuest(questID);
        }

        return base.CompleteQuest();
    }

    public int GetKilled()
    {
        return killed;
    }

    public void SetKilled(int killed)
    {
        this.killed = killed;
    }

    public CharacterBase GetEnemyToKill()
    {
        return enemyToKill;
    }

    override
    public QuestType GetQuestType()
    {
        return QuestType.KILL_QUEST;
    }
}
