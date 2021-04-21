using UnityEngine;

public static class Combat_Info
{
    private static Enemy_Info enemyInfo;
    private static Player_Info playerInfo;

    public static void Initialize()
    {
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Info>();
    }

    public static void ChangeEnemyInfo(Enemy_Info eInfo)
    {
        enemyInfo = eInfo;
    }

    public static Enemy_Info GetEnemyInfo()
    {
        return enemyInfo;
    }

    public static Player_Info GetPlayerInfo()
    {
        return playerInfo;
    }
}
