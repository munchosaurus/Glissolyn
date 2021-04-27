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

    public static void PlayerWins()
    {
        enemy.gameObject.SetActive(false);
        Console.WriteLine("Player exp before win: " + Game_Controller.GetPlayerInfo().GetExperience());
        Game_Controller.GetPlayerInfo().ModifyExperience(enemy.GetBase().GetExperienceBase() * enemy.GetLevel()/2);
        Console.WriteLine("Player exp after win: " + Game_Controller.GetPlayerInfo().GetExperience());
    }

    public static void EnemyWins()
    {
        //TODO - Do stuff when enemy wins.
    }
}
