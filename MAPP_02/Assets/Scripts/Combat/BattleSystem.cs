using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BattleSystem : MonoBehaviour
{
    [SerializeField] bool testing;
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud PlayerHud;
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] CharacterBase player;
    [SerializeField] CharacterBase enemy;

    public void StartCombat()
    {
        dialogBox.SetDialog("");
        if (!testing)
        {
            player = Combat_Info.GetPlayer();
            enemy = Combat_Info.GetEnemy();
        }
        StartCoroutine(SetupBattle(player, enemy));
         
    }


    public IEnumerator SetupBattle(CharacterBase player, CharacterBase enemy)
    {
        PlayerUnit.Setup(player);
        PlayerHud.SetData(PlayerUnit.Character);
        EnemyUnit.Setup(enemy);
        EnemyHud.SetData(EnemyUnit.Character);

        dialogBox.SetMoveNames(PlayerUnit.Character.Moves);

        yield return dialogBox.TypeDialog($" You encountered a {EnemyUnit.Character.Base.GetName()}!");
        yield return new WaitForSeconds(1.3f);
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

    public void pointClick(int i)
    {
        StartCoroutine(PerformPlayerMove(i));
    }

    public IEnumerator PerformPlayerMove(int index)
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);

        var move = PlayerUnit.Character.Moves[index];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        yield return dialogBox.TypeDialog($" You used ability: {move.Base.GetName()}");
        yield return new WaitForSeconds(1.3f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        yield return EnemyHud.UpdateHP();

        if (isDead)
        {
            yield return dialogBox.TypeDialog($"The {EnemyUnit.Character.Base.GetName()} died.");
            yield return new WaitForSeconds(2f);
            EndBattle(true);
        } else
        {
            StartCoroutine(EnemyMove());
        }
    }

    private IEnumerator EnemyMove()
    {    
        var move = EnemyUnit.Character.GetRandomMove();
        PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);

        yield return dialogBox.TypeDialog($"{EnemyUnit.Character.Base.name} used ability: {move.Base.GetName()}");
        yield return new WaitForSeconds(1.3f);

        bool isDead = PlayerUnit.Character.TakeDamage(move, PlayerUnit.Character);
        yield return PlayerHud.UpdateHP();

        if (isDead)
        {
            yield return dialogBox.TypeDialog($"The {PlayerUnit.Character.Base.GetName()} died.");
            yield return new WaitForSeconds(2f);
            EndBattle(true);
        }
        else
        {
            
            PlayerAction();
        }
    }

    void EndBattle(bool IsBattleOver)
    {
        if (IsBattleOver)
        {
            Combat_Info.PlayerWins();
            //Combat_Info.EnemyWins();
            Game_Controller.ToggleCombatState(false);
        }
    }

    public void Run(bool run)
    {
        if (run)
        {
            dialogBox.EnableActionSelector(false);
            Game_Controller.ToggleCombatState(false);
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
