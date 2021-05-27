using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud PlayerHud;
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    GameObject Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void StartCombat()
    {
        dialogBox.SetDialog("");
        StartCoroutine(SetupBattle());
        if (Combat_Info.GetEnemy().GetTypes().Contains(Type.Player))
        {
            Game_Controller.GetPlayerInfo().ChangeMusic(1);
        } else
        {
            Game_Controller.GetPlayerInfo().ChangeMusic(2);
        }
    }

    public IEnumerator SetupBattle()
    {
        PlayerUnit.Setup(Combat_Info.GetPlayer(), Combat_Info.GetPlayerLevel());
        PlayerHud.SetData(PlayerUnit.Character);
        EnemyUnit.Setup(Combat_Info.GetEnemy(), Combat_Info.GetEnemyLevel());
        EnemyHud.SetData(EnemyUnit.Character);

        dialogBox.SetMoveNames(PlayerUnit.Character.Moves);

        //$ möjliggör att man kan lägga till värden i strängen.
        yield return dialogBox.TypeDialog($"You encountered a {EnemyUnit.Character.Base.GetName()}!");
        yield return new WaitForSeconds(1.5f);
        PlayerAction();

    }

    public void PlayerAction()
    {
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
        
    }

    public void PlayerMove()
    {
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    public void PointClick(int i)
    {
        if(PlayerUnit.Character.Moves.Count > i)
        {
            StartCoroutine(PerformPlayerMove(i));
        }
        
    }

    public IEnumerator PerformPlayerMove(int index)
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);

        var move = PlayerUnit.Character.Moves[index];
        int damage = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        yield return dialogBox.TypeDialog($"You used ability: {move.Base.GetName()}.");
        //PlayerUnit.lerp.GoLerp();

        yield return new WaitForSeconds(1f);
        yield return dialogBox.TypeDialog($"It deals {damage} damage!");

        bool isDead = EnemyUnit.Character.CurrentHP <= 0;
        yield return EnemyHud.UpdateHP();

        if (isDead)
        {
            yield return dialogBox.TypeDialog($"The {EnemyUnit.Character.Base.GetName()} died.");
            yield return new WaitForSeconds(1f);
            EndBattle(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    private IEnumerator EnemyMove()
    {
        var move = EnemyUnit.Character.GetRandomMove();
        int damage = PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);

        yield return dialogBox.TypeDialog($"{EnemyUnit.Character.Base.name} used ability: {move.Base.GetName()}.");
        //EnemyUnit.lerp.GoLerp();

        yield return new WaitForSeconds(1f);
        yield return dialogBox.TypeDialog($"It deals {damage} damage!");

        bool isDead = PlayerUnit.Character.CurrentHP <= 0;
        yield return PlayerHud.UpdateHP();

        if (isDead)
        {
            yield return dialogBox.TypeDialog($"The {PlayerUnit.Character.Base.GetName()} died.");
            yield return new WaitForSeconds(2f);
            EndBattle(false);
        }
        else
        {

            PlayerAction();
        }
    }

    void EndBattle(bool PlayerWin)
    {
        if (PlayerWin) 
        {
            Combat_Info.PlayerWins();
            Game_Controller.RunTransition();
            EnemyUnit.Character.SetCurrentHP();
        } else {
            Combat_Info.EnemyWins();
            Game_Controller.RunTransition();
            Game_Controller.GetPlayerInfo().SetHealth(Game_Controller.GetPlayerInfo().GetMaxHealth());
            Vector3 temp = Game_Controller.GetPlayerInfo().GetRespawnPos();
            Player.transform.position = temp;
        }
    }

    public void Run(bool run)
    {
        if (run)
        {
            
            dialogBox.EnableActionSelector(false);
            EnemyUnit.Character.SetCurrentHP();
            Game_Controller.RunTransition();
        }
    }
}
public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy
}
