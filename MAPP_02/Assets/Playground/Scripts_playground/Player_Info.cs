using System.Collections.Generic;

public class Player_Info : Character_Info
{
    private int playerLevel; 
    private int statPoints;
    private int experience;

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public int GetExperience()
    {
        return experience;
    }

    public void ModifyExperience(int amount)
    {
        experience += amount;
    }

    public bool SpendStatPoint()
    {
        if(statPoints > 0)
        {
            statPoints--;
            return true;
        }

        return false;
    }
}
