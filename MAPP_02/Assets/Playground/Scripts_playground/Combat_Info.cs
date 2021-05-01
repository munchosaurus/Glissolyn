using System;
using UnityEngine;

public static class Combat_Info
{
    private static Enemy_Info enemy;
    private static CharacterBase player;

    public static void Initialize()
    {
        player = Game_Controller.GetPlayerInfo().GetBase();
    }

    public static void ChangeEnemy(Enemy_Info enemyInfo)
    {
        enemy = enemyInfo;
    }

    public static CharacterBase GetEnemy()
    {
        return enemy.GetBase();
    }

    public static CharacterBase GetPlayer()
    {
        return player;
    }

    public static int GetEnemyLevel()
    {
        return enemy.GetLevel();
    }

    public static int GetPlayerLevel()
    {
        return Game_Controller.GetPlayerInfo().GetPlayerLevel();
    }
    public static void PlayerWins()
    {
        Game_Controller.GetQuestLog().UpdateKillQuestsWithEnemyType(enemy.GetBase());
        enemy.gameObject.SetActive(false);
        Game_Controller.GetPlayerInfo().ModifyExperience(enemy.GetBase().GetExperienceBase() * ((enemy.GetLevel() * 2)/Game_Controller.GetPlayerInfo().GetPlayerLevel()));
        Console.WriteLine("Player gained " + enemy.GetBase().GetExperienceBase() * ((enemy.GetLevel() * 2) / Game_Controller.GetPlayerInfo().GetPlayerLevel()) + " experience.");
    }

    public static void EnemyWins()
    {
        //TODO - Do stuff when enemy wins.
    }
}
