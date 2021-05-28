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
        enemy.Die();
        int xpGained = Mathf.FloorToInt(enemy.GetBase().GetExperienceBase() * ((float) (enemy.GetLevel() * 2) / Game_Controller.GetPlayerInfo().GetPlayerLevel()) + 1);
        Game_Controller.GetPlayerInfo().ModifyExperience(xpGained);
    }

    public static void CombatEnded()
    {
        if(enemy.gameObject.TryGetComponent<Enemy_Find_player>(out Enemy_Find_player efp)){
            efp.StartTimer();
        }
    }

    public static void EnemyWins()
    {
        Game_Controller.GetDataBase().SetCurrentAudioID(4);
        Game_Controller.GetPlayerInfo().Respawn();
    }
}
