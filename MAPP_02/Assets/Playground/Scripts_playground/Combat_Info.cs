using UnityEngine;

public static class Combat_Info
{
    private static CharacterBase enemy;
    private static CharacterBase player;

    public static void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Info>().GetBase();
    }

    public static void ChangeEnemy(CharacterBase enemyBase)
    {
        enemy = enemyBase;
    }

    public static CharacterBase GetEnemy()
    {
        return enemy;
    }

    public static CharacterBase GetPlayer()
    {
        return player;
    }
}
